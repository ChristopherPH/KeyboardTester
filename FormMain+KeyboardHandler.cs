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

        public uint numpadKeysDown = 0;
        public RawInput rawInput;
        public RawInputKeyStates rawShiftKey;

        private void InitKeyboardHandler()
        {
            //Save state of shift key before capturing raw keyboard events
            rawShiftKey = Control.ModifierKeys.HasFlag(Keys.Shift) ?
                RawInputKeyStates.Down : RawInputKeyStates.Up;

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
            //Maintain raw shift state
            if (e.Key == Keys.ShiftKey)
                rawShiftKey = e.KeyState;
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

            return false;
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
