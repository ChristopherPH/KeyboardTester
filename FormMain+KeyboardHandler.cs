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

        public RawInput rawInput;
        public uint skipShiftUp = 0;
        public uint skipShiftDown = 0;
        public uint keysInFakeShift = 0;

        enum NumPadNumlockModes
        {
            Default,
            ShiftedNumberKey,
            IgnoreShift,
        }

        NumPadNumlockModes NumlockModes
        {
            get => _numlockModes;
            set
            {
                _numlockModes = value;
            }
        }
        NumPadNumlockModes _numlockModes = NumPadNumlockModes.Default;

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

            if (NumlockModes == NumPadNumlockModes.Default)
                return;

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
                    skipShiftDown++;
                    keysInFakeShift--;
                }
                else
                {
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

                    //Fix up number pad keys if within a fake shift block
                    if (keysInFakeShift > 0)
                        keyData = FixNumberPadKeys(msg, keyData,
                            NumlockModes == NumPadNumlockModes.IgnoreShift);

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

                    //Fix up number pad keys if within a fake shift block
                    if (keysInFakeShift > 0)
                        keyData = FixNumberPadKeys(msg, keyData,
                            NumlockModes == NumPadNumlockModes.IgnoreShift);

                    return HandleKeyPress(keyData, false);
            }

            return false;
        }

        private Keys FixNumberPadKeys(Message msg, Keys keyData, bool IgnoreNumlockAndShift)
        {
            var extended = ((msg.LParam.ToInt32() >> 24) & 1) != 0;

            if (((keyData & Keys.Modifiers) == 0) && (!extended))
            {
                Keys modKey = IgnoreNumlockAndShift ? Keys.None : Keys.Shift;

                switch (keyData)
                {
                    case Keys.Insert: keyData = (Keys.NumPad0 | modKey); break;

                    case Keys.End: keyData = (Keys.NumPad1 | modKey); break;
                    case Keys.Down: keyData = (Keys.NumPad2 | modKey); break;
                    case Keys.PageDown: keyData = (Keys.NumPad3 | modKey); break;

                    case Keys.Left: keyData = (Keys.NumPad4 | modKey); break;
                    case Keys.Clear: keyData = (Keys.NumPad5 | modKey); break;
                    case Keys.Right: keyData = (Keys.NumPad6 | modKey); break;

                    case Keys.Home: keyData = (Keys.NumPad7 | modKey); break;
                    case Keys.Up: keyData = (Keys.NumPad8 | modKey); break;
                    case Keys.PageUp: keyData = (Keys.NumPad9 | modKey); break;
                }
            }

            return keyData;
        }
    }
}
