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
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyboardTester
{
    public partial class FormMain: Form
    {
        public FormMain()
        {
            InitializeComponent();

            InitKeyboardHandler();

            CheckNumLock();

            LabelLookup = new Dictionary<Keys, Label>()
            {
                //[Keys.NumLock] = lblKeyNumLock,

                [Keys.ShiftKey] = lblKeyShift,
                [Keys.ControlKey] = lblKeyCtrl,
                [Keys.Menu] = lblKeyAlt,

                [Keys.Insert] = lblKeyIns,
                [Keys.Delete] = lblKeyDel,
                [Keys.Home] = lblKeyHome,
                [Keys.End] = lblKeyEnd,
                [Keys.PageUp] = lblKeyPgUp,
                [Keys.PageDown] = lblKeyPgDn,

                [Keys.Left] = lblKeyLeft,
                [Keys.Right] = lblKeyRight,
                [Keys.Up] = lblKeyUp,
                [Keys.Down] = lblKeyDown,

                [Keys.NumPad0] = lblKeyNum0,
                [Keys.NumPad1] = lblKeyNum1,
                [Keys.NumPad2] = lblKeyNum2,
                [Keys.NumPad3] = lblKeyNum3,
                [Keys.NumPad4] = lblKeyNum4,
                [Keys.NumPad5] = lblKeyNum5,
                [Keys.NumPad6] = lblKeyNum6,
                [Keys.NumPad7] = lblKeyNum7,
                [Keys.NumPad8] = lblKeyNum8,
                [Keys.NumPad9] = lblKeyNum9,

                [Keys.Decimal] = lblKeyNumDecimal,
            };
        }

        public Dictionary<Keys, ListViewItem> PressedKeys = new Dictionary<Keys, ListViewItem>();

        public Dictionary<Keys, Label> LabelLookup;

        void CheckNumLock()
        {
            var numLock = Control.IsKeyLocked(Keys.NumLock);

            rbNumLockDefault.Enabled = numLock;
            rbNumLockShifted.Enabled = numLock;
            rbNumLockIgnore.Enabled = numLock;
            chkIgnoreFakeShift.Enabled = numLock;
            lblKeyNumLock.Text = $"NmLk {(numLock ? "ON" : "OFF")}";

            if (!numLock)
            {
                lblInstructions.Text = @"NumLock is OFF:

Pressing a key on the numeric keypad will:
 - Trigger Home/End/PgUp/PgDown or Arrow key

Holding a shift key and pressing a key on the numeric keypad will:
 - Trigger a SHIFTED Home/End/PgUp/PgDown or Arrow key";
            }
            else
            {
                lblInstructions.Text = @"NumLock is ON:

When using standard Windows behaviour:

Pressing a key on the numeric keypad will:
 - Trigger a number key

Holding a single shift key and pressing a key on the numeric keypad will:
 - Unpress the shift key
 - Trigger a Home/End/PgUp/PgDown or Arrow key
 - Press the shift key

Holding both shift keys and pressing a key on the numeric keypad will:
 - Unpress one shift key
 - Trigger a SHIFTED Home/End/PgUp/PgDown or Arrow key
 - Press the shift key";
            }
        }

        public static bool CheckOnlyModifier(Keys keyData)
        {
            return ((keyData & Keys.KeyCode) == Keys.ShiftKey) ||
                ((keyData & Keys.KeyCode) == Keys.ControlKey) ||
                ((keyData & Keys.KeyCode) == Keys.Menu);
        }

        private bool HandleKeyPress(Keys keyData, bool keyDown)
        {
            //System.Diagnostics.Debug.Print($"    {(keyDown ? "Pressed" : "Released")} {keyData}");

            //Split keycode from modifiers
            var keyCode = keyData & Keys.KeyCode;
            var modifiers = keyData & Keys.Modifiers;

            //Strip own modifier from modifier keys

            var adjustedModifiers = modifiers;
            var adjustedKeyData = keyData;

            switch (keyCode)
            {
                case Keys.ShiftKey:
                    adjustedModifiers &= ~Keys.Shift;
                    adjustedKeyData = keyCode | adjustedModifiers;
                    break;

                case Keys.ControlKey:
                    adjustedModifiers &= ~Keys.Control;
                    adjustedKeyData = keyCode | adjustedModifiers;
                    break;

                case Keys.Menu:
                    adjustedModifiers &= ~Keys.Alt;
                    adjustedKeyData = keyCode | adjustedModifiers;
                    break;
            }

            //Log keypress
            if (adjustedModifiers != Keys.None)
                Log($"{(keyDown ? "Pressed" : "Released")} {keyCode} [{adjustedModifiers}]");
            else
                Log($"{(keyDown ? "Pressed" : "Released")} {keyCode}");

            //Update numlock text
            if (keyCode == Keys.NumLock)
                CheckNumLock();

            var lookupKey = keyCode;

            if (keyDown)
            {
                //Add new key to list
                if (!PressedKeys.TryGetValue(lookupKey, out var lvi))
                {
                    //need to clear all other repeats
                    foreach (ListViewItem lvii in lvPressedKeys.Items)
                    {
                        lvii.Tag = 0;
                        lvii.SubItems[4].Text = "";
                    }

                    lvi = new ListViewItem(new string[]
                    {
                        keyCode.ToString(),
                        modifiers.HasFlag(Keys.Control) ? "Ctrl" : "",
                        modifiers.HasFlag(Keys.Alt) ? "Alt" : "",
                        modifiers.HasFlag(Keys.Shift) ? "Shift" : "",
                        "",
                    })
                    {
                        Tag = 0,
                    };
                    PressedKeys[lookupKey] = lvi;
                    lvPressedKeys.Items.Add(lvi);
                    lvi.Selected = false;
                    lvi.Focused = false;

                    if (LabelLookup.TryGetValue(lookupKey, out var label))
                    {
                        var txt = $"{lookupKey}";
                        if (modifiers.HasFlag(Keys.Control)) txt += " [Ctrl]";
                        if (modifiers.HasFlag(Keys.Alt)) txt += " [Alt]";
                        if (modifiers.HasFlag(Keys.Shift)) txt += " [Shift]";
                        label.Text = txt;
                    }
                }
                else //update repeating key
                {
                    //need to clear all other repeats
                    foreach (ListViewItem lvii in lvPressedKeys.Items)
                    {
                        if (lvii == lvi)
                            continue;

                        lvii.Tag = 0;
                        lvii.SubItems[4].Text = "";
                    }

                    var count = ((int)lvi.Tag) + 1;
                    lvi.Tag = count;
                    lvi.SubItems[4].Text = count.ToString();

                    //technically modifiers may have changed
                    lvi.SubItems[1].Text = modifiers.HasFlag(Keys.Control) ? "Ctrl" : "";
                    lvi.SubItems[2].Text = modifiers.HasFlag(Keys.Alt) ? "Alt" : "";
                    lvi.SubItems[3].Text = modifiers.HasFlag(Keys.Shift) ? "Shift" : "";

                    if (LabelLookup.TryGetValue(lookupKey, out var label))
                    {
                        var txt = $"{lookupKey}";
                        if (modifiers.HasFlag(Keys.Control)) txt += " [Ctrl]";
                        if (modifiers.HasFlag(Keys.Alt)) txt += " [Alt]";
                        if (modifiers.HasFlag(Keys.Shift)) txt += " [Shift]";
                        label.Text = txt;
                    }
                }
            }
            else //keyUp
            {
                if (!PressedKeys.TryGetValue(lookupKey, out var lvi))
                {
                    Log($"ERROR: Released {keyCode} without associated press");
                }
                else //remove key
                {
                    lvPressedKeys.Items.Remove(lvi);
                    PressedKeys.Remove(lookupKey);

                    foreach (ListViewItem lvii in lvPressedKeys.Items)
                    {
                        lvii.Tag = 0;
                        lvii.SubItems[4].Text = "";
                    }

                    if (LabelLookup.TryGetValue(lookupKey, out var label))
                        label.Text = "";
                }
            }

            return true; //indicate message has been handled
        }

        private void rbNumLockDefault_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockMode = NumberPadAdjustmentModes.Unshift;
            }
        }

        private void rbNumLockShifted_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockMode = NumberPadAdjustmentModes.Shift;
            }
        }

        private void rbNumLockIgnore_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockMode = NumberPadAdjustmentModes.Ignore;
            }
        }

        private void chkIgnoreFakeShift_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
                SkipFakeShiftKeyPresses = cb.Checked;
        }

        private void Log(string message)
        {
            if (txtLog.TextLength == 0)
                txtLog.Text = message;
            else
                txtLog.AppendText(Environment.NewLine + message);
        }

        private void LogRaw(string message)
        {
            if (txtRawLog.TextLength == 0)
                txtRawLog.Text = message;
            else
                txtRawLog.AppendText(Environment.NewLine + message);

            System.Diagnostics.Debug.Print(message);
        }
    }
}

