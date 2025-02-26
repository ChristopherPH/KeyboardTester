/*
 * Copyright (c) 2025 Christopher Hayes
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System.Windows.Forms;
using TheBlackRoom.WinForms.Keyboard;

namespace KeyboardTester
{
    public partial class FormMain : IMessageFilter
    {
        private RawInput rawInput;
        private uint skipShiftUp = 0;
        private uint skipShiftDown = 0;
        private uint keysInFakeShift = 0;

        /// <summary>
        /// Numeric Keypad adjustment modes:
        /// When NumLock is ON, shift is held down, and a numeric keypad key is pressed
        /// </summary>
        enum NumberPadAdjustmentModes
        {
            /// <summary>
            /// Unshift numeric keypad key (This is standard Windows behaviour)
            /// Treat as if numlock is off and shift is not held down
            /// </summary>
            Unshift,

            /// <summary>
            /// Shift the numeric keypad key
            /// </summary>
            Shift,

            /// <summary>
            /// Ignore the shift key
            /// </summary>
            Ignore,
        }

        bool SkipFakeShiftKeyPresses { get; set; } = false;


        NumberPadAdjustmentModes NumlockMode { get; set; } = NumberPadAdjustmentModes.Unshift;

        private void InitKeyboardHandler()
        {
            //Setup raw input capture, used to handle shift numberpad
            //keys when numlock is on
            rawInput = new RawInput(this);
            rawInput.RawInputKeyboard += rawInput_RawInputKeyboard;

            //Setup keyboard event capture
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
        }

        private void rawInput_RawInputKeyboard(object sender, RawInputKeyboardEventArgs e)
        {
            //System.Diagnostics.Debug.Print($"RAW {(e.KeyState == RawInputKeyStates.Down ? "Pressed" : "Released")} {e.Key}");

            /* Key is shift, but scancode is not left or right shift
             * (Scancode will be that of key that generated fake press)
             * https://learn.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input
             * Set flags to skip shift key events inside PreFilterMessage()
             * as keyboard events can't be skipped here
             */
            if ((e.Key == Keys.ShiftKey) && (e.ScanCode != 0x002A) && (e.ScanCode != 0x0036))
            {
                if (e.KeyState == RawInputKeyStates.Down)
                {
                    if (SkipFakeShiftKeyPresses)
                        skipShiftDown++;

                    keysInFakeShift--;
                }
                else
                {
                    if (SkipFakeShiftKeyPresses)
                        skipShiftUp++;

                    keysInFakeShift++;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //Handle raw input events
            rawInput?.HandleWndProc(m);
        }

        /* Use IMessageFilter.PreFilterMessage to capture keyboard events,
         * to avoid complications with ProcessCmdKey() and ProcessKeyPreview() */
        bool IMessageFilter.PreFilterMessage(ref Message msg)
        {
            Keys keyData;

            switch (msg.Msg)
            {
                case KeyboardUtility.WM_KEYDOWN:
                case KeyboardUtility.WM_SYSKEYDOWN:
                    keyData = (Keys)msg.WParam | ModifierKeys;

                    //Skip shift key event if flagged
                    if ((skipShiftDown > 0) && ((keyData & Keys.KeyCode) == Keys.ShiftKey))
                    {
                        skipShiftDown--;
                        return true;
                    }

                    //Adjust number pad keys if within a fake shift block
                    keyData = AdjustNumberPadKeyData(msg, keyData,
                        Control.IsKeyLocked(Keys.NumLock),
                        keysInFakeShift > 0, NumlockMode);

                    return HandleKeyPress(keyData, true);

                case KeyboardUtility.WM_KEYUP:
                case KeyboardUtility.WM_SYSKEYUP:
                    keyData = (Keys)msg.WParam | ModifierKeys;

                    //Skip shift key event if flagged
                    if ((skipShiftUp > 0) && ((keyData & Keys.KeyCode) == Keys.ShiftKey))
                    {
                        skipShiftUp--;
                        return true;
                    }

                    //Adjust number pad keys if within a fake shift block
                    keyData = AdjustNumberPadKeyData(msg, keyData,
                        Control.IsKeyLocked(Keys.NumLock),
                        keysInFakeShift > 0, NumlockMode);

                    return HandleKeyPress(keyData, false);
            }

            return false;
        }

        private static Keys AdjustNumberPadKeyData(Message msg, Keys keyData,
            bool numLock, bool inFakeShift, NumberPadAdjustmentModes adjustmentMode)
        {
            //Only need to adjust when numlock is on, and in a fake shift,
            //and adjustment mode is not the default.
            if (!numLock || !inFakeShift || (adjustmentMode == NumberPadAdjustmentModes.Unshift))
                return keyData;

            //Split keycode from modifiers
            var keyCode = keyData & Keys.KeyCode;
            var modifiers = keyData & Keys.Modifiers;

            /* Get extended flag from message:
             * https://learn.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input#extended-key-flag
             * var extended = ((msg.LParam.ToInt32() >> 24) & 1) != 0; */
            if (!KeyboardUtility.ParseKeyboardMessage(msg, Keys.None, out _, out _, out var flags, out _))
                return keyData;

            var extended = flags.HasFlag(KeyboardUtility.KeystrokeFlags.KF_EXTENDED);

            /* The shifted keys are the arrows and INS, DEL, HOME, END, PAGE UP, PAGE DOWN. Reading the following:
             * https://docs.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input#keystroke-message-flags
             * notes that the arrows and INS, DEL, HOME, END, PAGE UP, PAGE DOWN not on the numeric keypad get
             * an extended flag (lParam bit 24), so we can assume if this flag is false for those keys, we are
             * using the numeric keypad. So if the key is an unshifted numberpad key, update the key */
            if (!extended && !modifiers.HasFlag(Keys.Shift))
            {
                switch (keyCode)
                {
                    case Keys.Insert: keyCode = Keys.NumPad0; break;

                    case Keys.End: keyCode = Keys.NumPad1; break;
                    case Keys.Down: keyCode = Keys.NumPad2; break;
                    case Keys.PageDown: keyCode = Keys.NumPad3; break;

                    case Keys.Left: keyCode = Keys.NumPad4; break;
                    case Keys.Clear: keyCode = Keys.NumPad5; break;
                    case Keys.Right: keyCode = Keys.NumPad6; break;

                    case Keys.Home: keyCode = Keys.NumPad7; break;
                    case Keys.Up: keyCode = Keys.NumPad8; break;
                    case Keys.PageUp: keyCode = Keys.NumPad9; break;
                }

                //Add shift modifier to the key
                if (adjustmentMode == NumberPadAdjustmentModes.Shift)
                    modifiers |= Keys.Shift;

                //Rebuild key press
                keyData = keyCode | modifiers;
            }

            return keyData;
        }
    }
}
