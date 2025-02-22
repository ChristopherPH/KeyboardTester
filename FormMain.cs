﻿using System.Windows.Forms;

namespace KeyboardTester
{
    public partial class FormMain: Form
    {
        public FormMain()
        {
            InitializeComponent();

            InitKeyboardHandler();
        }

        private void HandleKeyPress(Keys keyData, bool keyDown)
        {
            System.Diagnostics.Debug.Print($"{(keyDown ? "Pressed" : "Released")} {keyData}");
        }
    }
}
