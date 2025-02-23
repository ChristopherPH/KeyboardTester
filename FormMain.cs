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
        }

        public Dictionary<Keys, ListViewItem> PressedKeys = new Dictionary<Keys, ListViewItem>();

        void CheckNumLock()
        {
            var numLock = Control.IsKeyLocked(Keys.NumLock);

            rbNumLockDefault.Enabled = numLock;
            rbNumLockShifted.Enabled = numLock;
            rbNumLockIgnore.Enabled = numLock;

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
                txtLog.AppendText($"{(keyDown ? "Pressed" : "Released")} {keyCode} [{adjustedModifiers}]" + Environment.NewLine);
            else
                txtLog.AppendText($"{(keyDown ? "Pressed" : "Released")} {keyCode}" + Environment.NewLine);

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

            return true; //indicate message has been handled
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
                NumlockModes = NumPadNumlockModes.ShiftedNumberKey;
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

