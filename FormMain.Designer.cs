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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbNumLock = new System.Windows.Forms.GroupBox();
            this.rbNumLockIgnore = new System.Windows.Forms.RadioButton();
            this.rbNumLockShifted = new System.Windows.Forms.RadioButton();
            this.rbNumLockDefault = new System.Windows.Forms.RadioButton();
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
            this.lblInstructions.Size = new System.Drawing.Size(598, 293);
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
            this.lvPressedKeys.HideSelection = false;
            this.lvPressedKeys.Location = new System.Drawing.Point(12, 305);
            this.lvPressedKeys.MultiSelect = false;
            this.lvPressedKeys.Name = "lvPressedKeys";
            this.lvPressedKeys.Size = new System.Drawing.Size(598, 281);
            this.lvPressedKeys.TabIndex = 1;
            this.lvPressedKeys.UseCompatibleStateImageBehavior = false;
            this.lvPressedKeys.View = System.Windows.Forms.View.Details;
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
            // gbNumLock
            // 
            this.gbNumLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNumLock.Controls.Add(this.rbNumLockIgnore);
            this.gbNumLock.Controls.Add(this.rbNumLockShifted);
            this.gbNumLock.Controls.Add(this.rbNumLockDefault);
            this.gbNumLock.Location = new System.Drawing.Point(616, 9);
            this.gbNumLock.Name = "gbNumLock";
            this.gbNumLock.Size = new System.Drawing.Size(336, 290);
            this.gbNumLock.TabIndex = 2;
            this.gbNumLock.TabStop = false;
            this.gbNumLock.Text = "Shift + Numeric Keypad Handling";
            // 
            // rbNumLockIgnore
            // 
            this.rbNumLockIgnore.Location = new System.Drawing.Point(17, 182);
            this.rbNumLockIgnore.Name = "rbNumLockIgnore";
            this.rbNumLockIgnore.Size = new System.Drawing.Size(300, 100);
            this.rbNumLockIgnore.TabIndex = 5;
            this.rbNumLockIgnore.Text = "Ignore Shift:\r\nInstead of unshifting the number key back to Home/End/Arrows, trig" +
    "ger a number key without shift";
            this.rbNumLockIgnore.UseVisualStyleBackColor = true;
            this.rbNumLockIgnore.CheckedChanged += new System.EventHandler(this.rbNumLockIgnore_CheckedChanged);
            // 
            // rbNumLockShifted
            // 
            this.rbNumLockShifted.Location = new System.Drawing.Point(17, 83);
            this.rbNumLockShifted.Name = "rbNumLockShifted";
            this.rbNumLockShifted.Size = new System.Drawing.Size(300, 100);
            this.rbNumLockShifted.TabIndex = 4;
            this.rbNumLockShifted.Text = "Shifted Number Key:\r\nInstead of unshifting the number key back to Home/End/Arrows" +
    ", trigger a SHIFTED number key";
            this.rbNumLockShifted.UseVisualStyleBackColor = true;
            this.rbNumLockShifted.CheckedChanged += new System.EventHandler(this.rbNumLockShifted_CheckedChanged);
            // 
            // rbNumLockDefault
            // 
            this.rbNumLockDefault.Checked = true;
            this.rbNumLockDefault.Location = new System.Drawing.Point(17, 25);
            this.rbNumLockDefault.Name = "rbNumLockDefault";
            this.rbNumLockDefault.Size = new System.Drawing.Size(300, 50);
            this.rbNumLockDefault.TabIndex = 0;
            this.rbNumLockDefault.TabStop = true;
            this.rbNumLockDefault.Text = "Default:\r\nAuto unshift, trigger keypress, re-shift";
            this.rbNumLockDefault.UseVisualStyleBackColor = true;
            this.rbNumLockDefault.CheckedChanged += new System.EventHandler(this.rbNumLockDefault_CheckedChanged);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(616, 305);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(336, 281);
            this.txtLog.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 598);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gbNumLock);
            this.Controls.Add(this.lvPressedKeys);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Tester";
            this.gbNumLock.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton rbNumLockIgnore;
        private System.Windows.Forms.RadioButton rbNumLockShifted;
        private System.Windows.Forms.TextBox txtLog;
    }
}

