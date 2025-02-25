using System;
using System.Windows.Forms;

namespace TheBlackRoom.WinForms.Keyboard
{
    /// <summary>
    /// Event data for Raw Keyboard Input
    /// </summary>
    public class RawInputKeyboardEventArgs : EventArgs
    {
        public RawInputKeyboardEventArgs(Keys Key, RawInputKeyStates KeyState, ushort ScanCode,
            ushort Flags, uint Message, ulong ExtraInformation)
        {
            this.Key = Key;
            this.KeyState = KeyState;
            this.ScanCode = ScanCode;
            this.Flags = Flags;
            this.Message = Message;
            this.ExtraInformation = ExtraInformation;
        }

        public Keys Key { get; }
        public RawInputKeyStates KeyState { get; }
        public ushort ScanCode { get; }
        public ushort Flags { get; }
        public uint Message { get; }
        public ulong ExtraInformation { get; }

        public bool FlagsKeyBreak => (Flags & RawInput.NativeMethods.RI_KEY_BREAK) == RawInput.NativeMethods.RI_KEY_BREAK;
        public bool FlagsE0 => (Flags & RawInput.NativeMethods.RI_KEY_E0) == RawInput.NativeMethods.RI_KEY_E0;
        public bool FlagsE1 => (Flags & RawInput.NativeMethods.RI_KEY_E1) == RawInput.NativeMethods.RI_KEY_E1;
    }
}
