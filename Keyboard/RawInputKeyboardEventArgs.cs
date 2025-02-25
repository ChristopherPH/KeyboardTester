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
