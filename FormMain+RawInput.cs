using System.Windows.Forms;
using TheBlackRoom.WinForms.Keyboard;

namespace KeyboardTester
{
    public partial class FormMain
    {
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        public uint numpadKeysDown = 0;
        public RawInput rawInput;
        public RawInputKeyStates rawShiftKey;

        private void InitRawInput()
        {
            rawShiftKey = Control.ModifierKeys.HasFlag(Keys.Shift) ?
                RawInputKeyStates.Down : RawInputKeyStates.Up;

            rawInput = new RawInput(this);
            rawInput.RawInputKeyboard += rawInput_RawInputKeyboard;
        }

        private void rawInput_RawInputKeyboard(object sender, RawInputKeyboardEventArgs e)
        {
            if (e.Key == Keys.ShiftKey)
                rawShiftKey = e.KeyState;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            rawInput?.HandleWndProc(m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //in order to get as much control over keys, ProcessCmdKey()
            //becomes the KEYDOWN handler.
            if (numpadKeysDown > 0)
            {
                if ((keyData & Keys.KeyCode) == Keys.ShiftKey)
                {
                    numpadKeysDown--;
                    return true;
                }

                keyData = FixNumberPadKeys(msg, keyData);
            }

            HandleKeyPress(keyData, true);

            //returning true eats ProcessKeyPreview, OnKeyDown
            return true;
        }

        /*
         * ProcessKeyPreview() only gets called when there is
         * a control on the form
         */
        protected override bool ProcessKeyPreview(ref Message msg)
        {
            Keys keyData;

            switch (msg.Msg)
            {
                //KeyDown events don't trigger, as ProcessCmdKey()
                //returns true
                case WM_KEYDOWN:
                case WM_SYSKEYDOWN:
                    keyData = (Keys)msg.WParam | ModifierKeys;

                    if (numpadKeysDown > 0)
                    {
                        if ((keyData & Keys.KeyCode) == Keys.ShiftKey)
                        {
                            numpadKeysDown--;
                            return true;
                        }

                        keyData = FixNumberPadKeys(msg, keyData);
                    }

                    HandleKeyPress(keyData, true);
                    break;

                case WM_KEYUP:
                case WM_SYSKEYUP:
                    keyData = (Keys)msg.WParam | ModifierKeys;

                    if ((keyData & Keys.KeyCode) == Keys.ShiftKey)
                    {
                        var numlock = Control.IsKeyLocked(Keys.NumLock);

                        if (numlock && (rawShiftKey == RawInputKeyStates.Down))
                        {
                            numpadKeysDown++;
                            return true;
                        }
                    }

                    if (numpadKeysDown > 0)
                        keyData = FixNumberPadKeys(msg, keyData);

                    HandleKeyPress(keyData, false);
                    break;
            }

            return base.ProcessKeyPreview(ref msg);
        }

        private Keys FixNumberPadKeys(Message msg, Keys keyData)
        {
            var extended = ((msg.LParam.ToInt32() >> 24) & 1) != 0;

            if (((keyData & Keys.Modifiers) == 0) && (!extended))
            {
                switch (keyData)
                {
                    case Keys.Insert: keyData = (Keys.NumPad0 | Keys.Shift); break;

                    case Keys.End: keyData = (Keys.NumPad1 | Keys.Shift); break;
                    case Keys.Down: keyData = (Keys.NumPad2 | Keys.Shift); break;
                    case Keys.PageDown: keyData = (Keys.NumPad3 | Keys.Shift); break;

                    case Keys.Left: keyData = (Keys.NumPad4 | Keys.Shift); break;
                    case Keys.Clear: keyData = (Keys.NumPad5 | Keys.Shift); break;
                    case Keys.Right: keyData = (Keys.NumPad6 | Keys.Shift); break;

                    case Keys.Home: keyData = (Keys.NumPad7 | Keys.Shift); break;
                    case Keys.Up: keyData = (Keys.NumPad8 | Keys.Shift); break;
                    case Keys.PageUp: keyData = (Keys.NumPad9 | Keys.Shift); break;
                }
            }

            return keyData;
        }
    }
}
