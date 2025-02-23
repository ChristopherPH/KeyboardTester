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

            lblNumLock.Text = $"NumLock: {(Control.IsKeyLocked(Keys.NumLock) ? "ON" : "OFF")}";

            lblInstructions.Text = @"Notes:

When NumLock is off, pressing a key on the numeric keypad will trigger a home/end/pgup/pgdown/arrow key.

When NumLock is on, pressing a key on the numeric keypad will trigger a number key.

When NumLock is on, and a single shift key is held down, pressing a key on the numeric keypad will remove the shift, trigger a home/end/pgup/pgdown/arrow key, then add back the shift.
";
        }

        public Dictionary<Keys, ListViewItem> PressedKeys = new Dictionary<Keys, ListViewItem>();

        public static bool CheckOnlyModifier(Keys keyData)
        {
            return ((keyData & Keys.KeyCode) == Keys.ShiftKey) ||
                ((keyData & Keys.KeyCode) == Keys.ControlKey) ||
                ((keyData & Keys.KeyCode) == Keys.Menu);
        }

        private bool HandleKeyPress(Keys keyData, bool keyDown)
        {
            System.Diagnostics.Debug.Print($"{(keyDown ? "Pressed" : "Released")} {keyData}");

            //Split keycode from modifiers
            var keyCode = keyData & Keys.KeyCode;
            var modifiers = keyData & Keys.Modifiers;

            //Strip own modifier from modifier keys
            switch (keyCode)
            {
                case Keys.ShiftKey:
                    modifiers &= ~Keys.Shift;
                    keyData = keyCode | modifiers;
                    break;

                case Keys.ControlKey:
                    modifiers &= ~Keys.Control;
                    keyData = keyCode | modifiers;
                    break;

                case Keys.Menu:
                    modifiers &= ~Keys.Alt;
                    keyData = keyCode | modifiers;
                    break;
            }

            //Log keypress
            if (modifiers != Keys.None)
                txtLog.AppendText($"{(keyDown ? "Pressed" : "Released")} {keyCode} [{modifiers}]" + Environment.NewLine);
            else
                txtLog.AppendText($"{(keyDown ? "Pressed" : "Released")} {keyCode}" + Environment.NewLine);

            //Update numlock text
            if (keyCode == Keys.NumLock)
            {
                lblNumLock.Text = $"NumLock: {(Control.IsKeyLocked(Keys.NumLock) ? "ON" : "OFF")}";
            }

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
                }
            }
            else //keyUp
            {
                if (!PressedKeys.TryGetValue(lookupKey, out var lvi))
                {
                    txtLog.AppendText($"ERROR: Released {keyCode} without associated press" + Environment.NewLine);
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
                }
            }

            return true; //indicate message has been handledaaaa
        }

        private void rbNumLockDefault_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockModes = NumPadNumlockModes.Default;
            }
        }

        private void rbNumLockShifted_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockModes = NumPadNumlockModes.ShiftShifted;
            }
        }

        private void rbNumLockIgnore_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb) && (rb.Checked))
            {
                NumlockModes = NumPadNumlockModes.IgnoreShift;
            }
        }
    }
}

