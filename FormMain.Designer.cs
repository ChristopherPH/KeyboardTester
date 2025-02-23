﻿namespace KeyboardTester
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lvPressedKeys = new System.Windows.Forms.ListView();
            this.gbNumLock = new System.Windows.Forms.GroupBox();
            this.rbNumLockDefault = new System.Windows.Forms.RadioButton();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNumLock = new System.Windows.Forms.Label();
            this.rbNumLockShifted = new System.Windows.Forms.RadioButton();
            this.rbNumLockIgnore = new System.Windows.Forms.RadioButton();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.gbNumLock.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(518, 264);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Instructions:";
            // 
            // lvPressedKeys
            // 
            this.lvPressedKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPressedKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvPressedKeys.FullRowSelect = true;
            this.lvPressedKeys.GridLines = true;
            this.lvPressedKeys.Location = new System.Drawing.Point(12, 279);
            this.lvPressedKeys.MultiSelect = false;
            this.lvPressedKeys.Name = "lvPressedKeys";
            this.lvPressedKeys.Size = new System.Drawing.Size(518, 196);
            this.lvPressedKeys.TabIndex = 1;
            this.lvPressedKeys.UseCompatibleStateImageBehavior = false;
            this.lvPressedKeys.View = System.Windows.Forms.View.Details;
            // 
            // gbNumLock
            // 
            this.gbNumLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNumLock.Controls.Add(this.rbNumLockIgnore);
            this.gbNumLock.Controls.Add(this.rbNumLockShifted);
            this.gbNumLock.Controls.Add(this.rbNumLockDefault);
            this.gbNumLock.Location = new System.Drawing.Point(536, 9);
            this.gbNumLock.Name = "gbNumLock";
            this.gbNumLock.Size = new System.Drawing.Size(336, 217);
            this.gbNumLock.TabIndex = 2;
            this.gbNumLock.TabStop = false;
            this.gbNumLock.Text = "Shift + Numpad + Numlock Handling";
            // 
            // rbNumLockDefault
            // 
            this.rbNumLockDefault.AutoSize = true;
            this.rbNumLockDefault.Checked = true;
            this.rbNumLockDefault.Location = new System.Drawing.Point(17, 40);
            this.rbNumLockDefault.Name = "rbNumLockDefault";
            this.rbNumLockDefault.Size = new System.Drawing.Size(218, 24);
            this.rbNumLockDefault.TabIndex = 0;
            this.rbNumLockDefault.Text = "Default (unshift, key, shift)";
            this.rbNumLockDefault.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ctrl";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alt";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Shift";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Repeat";
            this.columnHeader5.Width = 80;
            // 
            // lblNumLock
            // 
            this.lblNumLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumLock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumLock.Location = new System.Drawing.Point(536, 229);
            this.lblNumLock.Name = "lblNumLock";
            this.lblNumLock.Size = new System.Drawing.Size(336, 44);
            this.lblNumLock.TabIndex = 3;
            this.lblNumLock.Text = "NumLock";
            this.lblNumLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbNumLockShifted
            // 
            this.rbNumLockShifted.AutoSize = true;
            this.rbNumLockShifted.Location = new System.Drawing.Point(17, 70);
            this.rbNumLockShifted.Name = "rbNumLockShifted";
            this.rbNumLockShifted.Size = new System.Drawing.Size(135, 24);
            this.rbNumLockShifted.TabIndex = 4;
            this.rbNumLockShifted.Text = "Shift + Shifted";
            this.rbNumLockShifted.UseVisualStyleBackColor = true;
            // 
            // rbNumLockIgnore
            // 
            this.rbNumLockIgnore.AutoSize = true;
            this.rbNumLockIgnore.Location = new System.Drawing.Point(17, 100);
            this.rbNumLockIgnore.Name = "rbNumLockIgnore";
            this.rbNumLockIgnore.Size = new System.Drawing.Size(117, 24);
            this.rbNumLockIgnore.TabIndex = 5;
            this.rbNumLockIgnore.Text = "Ignore Shift";
            this.rbNumLockIgnore.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(536, 279);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(336, 196);
            this.txtLog.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 487);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gbNumLock);
            this.Controls.Add(this.lblNumLock);
            this.Controls.Add(this.lvPressedKeys);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Tester";
            this.gbNumLock.ResumeLayout(false);
            this.gbNumLock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.ListView lvPressedKeys;
        private System.Windows.Forms.GroupBox gbNumLock;
        private System.Windows.Forms.RadioButton rbNumLockDefault;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblNumLock;
        private System.Windows.Forms.RadioButton rbNumLockIgnore;
        private System.Windows.Forms.RadioButton rbNumLockShifted;
        private System.Windows.Forms.TextBox txtLog;
    }
}

