using System.Windows.Forms;
using TheBlackRoom.WinForms.Keyboard;

namespace KeyboardTester
{
    public partial class FormMain : IMessageFilter
    {
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

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
                case WM_KEYDOWN:
                case WM_SYSKEYDOWN:
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

                case WM_KEYUP:
                case WM_SYSKEYUP:
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
            if (!numLock || (adjustmentMode == NumberPadAdjustmentModes.Unshift))
                return keyData;

            //Split keycode from modifiers
            var keyCode = keyData & Keys.KeyCode;
            var modifiers = keyData & Keys.Modifiers;

            //Get extended flag from message
            var extended = ((msg.LParam.ToInt32() >> 24) & 1) != 0;

            //If the key is an unshifted numberpad key, then update the key
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
