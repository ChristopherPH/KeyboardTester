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

            /* Check for any 'fake' shift keys:
             * A fake shift will generally come before a real keypress, and the fake
             * shift scancode and keybreak flags match that of the real keypress event.
             * Set flags to skip shift key events inside PreFilterMessage() as keyboard
             * events can't be skipped using raw input. */
            if (e.Key == Keys.ShiftKey)
            {
                /* Set flag if the key is a shift key, but scancode is not left or right shift
                 * (The scancode will be that of key that generated fake press)
                 * https://learn.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input */
                bool shiftScanCode = (e.ScanCode == 0x002A) || (e.ScanCode == 0x0036);

                /* Set flag if the WM_KEYDOWN/WM_KEYUP event doesn't match the
                 * KeyBreak (key up) flag */
                bool keyStateMismatch = (e.KeyState == RawInputKeyStates.Down) == e.FlagsKeyBreak;

                /* Handle shift key up */
                if (e.KeyState == RawInputKeyStates.Up)
                {
                    /* A fake shift up always comes before the real keypress, so its safe
                     * to just check for a scancode mismatch to determine a fake shift up
                     * Note: If keyStateMismatch is true, then the previous raw input was
                     *       either a fake or real a shift down. */
                    if (!shiftScanCode)
                    {
                        System.Diagnostics.Debug.Print($"[{keysInFakeShift}] Released {e.Key}/0x{e.ScanCode:X} (Fake Shift Up)" +
                            $"{(!keyStateMismatch ? " (Prev was Real/Fake Shift Down)" : "")} ");

                        if (SkipFakeShiftKeyPresses)
                            skipShiftUp++;

                        keysInFakeShift++;
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print($"[{keysInFakeShift}] Released {e.Key}/0x{e.ScanCode:X} (Real Shift Up)");
                    }
                }
                else if (e.KeyState == RawInputKeyStates.Down)
                {
                    /* A fake shift down doesn't always comes before the real keypress, so
                     * check for a scancode mismatch to determine if a fake shift down,
                     * then check for a keyStateMismatch while in a fake shift.
                     * Note: If shiftScanCode is false and keyStateMismatch is false,
                     *       then the next raw input will be fake a shift up.
                     * Note: If keyStateMismatch is true, then the next raw input will be
                     *       real a shift up. */
                    if (!shiftScanCode || (keyStateMismatch && (keysInFakeShift > 0)))
                    {
                        if (SkipFakeShiftKeyPresses)
                            skipShiftDown++;

                        keysInFakeShift--;

                        if (!shiftScanCode)
                            System.Diagnostics.Debug.Print($"[{keysInFakeShift}] Pressed {e.Key}/0x{e.ScanCode:X} (Fake Shift Down)" +
                                $"{(!keyStateMismatch ? " (Next is Fake Shift Up)" : "")} ");
                        else
                            System.Diagnostics.Debug.Print($"[{keysInFakeShift}] Pressed {e.Key}/0x{e.ScanCode:X} (Fake Shift Down)" +
                                $" (Next is Real Shift Up)");
                    }
                    else if (keysInFakeShift > 0)
                    {
                        /* If a real shift happens when there are still keysInFakeShift,
                         * a fake shift down was not generated due to repeating real shift key,
                         * so the outstanding keysInFakeShift needs to be cleared.
                         * Note: When this happens, the last fake shift up would have been
                         *       preceeded by a real shift down */
                        System.Diagnostics.Debug.Print($"[{keysInFakeShift}] " +  $"Missing Fake Shift due to repeating Real Shift Down");

                        keysInFakeShift = 0;
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print($"[{keysInFakeShift}] Pressed {e.Key}/0x{e.ScanCode:X} (Real Shift Down)");
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.Print($"[{keysInFakeShift}] " +
                    $"{(e.KeyState == RawInputKeyStates.Down ? "Pressed" : "Released")} {e.Key}/0x{e.ScanCode:X} ");
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
