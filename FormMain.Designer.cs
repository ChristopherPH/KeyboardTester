namespace KeyboardTester
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
            this.chkIgnoreFakeShift = new System.Windows.Forms.CheckBox();
            this.rbNumLockIgnore = new System.Windows.Forms.RadioButton();
            this.rbNumLockShifted = new System.Windows.Forms.RadioButton();
            this.rbNumLockDefault = new System.Windows.Forms.RadioButton();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtRawLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKeyIns = new System.Windows.Forms.Label();
            this.lblKeyHome = new System.Windows.Forms.Label();
            this.lblKeyPgUp = new System.Windows.Forms.Label();
            this.lblKeyDel = new System.Windows.Forms.Label();
            this.lblKeyEnd = new System.Windows.Forms.Label();
            this.lblKeyPgDn = new System.Windows.Forms.Label();
            this.lblKeyUp = new System.Windows.Forms.Label();
            this.lblKeyLeft = new System.Windows.Forms.Label();
            this.lblKeyDown = new System.Windows.Forms.Label();
            this.lblKeyRight = new System.Windows.Forms.Label();
            this.lblKeyNum7 = new System.Windows.Forms.Label();
            this.lblKeyNum4 = new System.Windows.Forms.Label();
            this.lblKeyNum8 = new System.Windows.Forms.Label();
            this.lblKeyNum9 = new System.Windows.Forms.Label();
            this.lblKeyNumDecimal = new System.Windows.Forms.Label();
            this.lblKeyNum0 = new System.Windows.Forms.Label();
            this.lblKeyNum5 = new System.Windows.Forms.Label();
            this.lblKeyNum6 = new System.Windows.Forms.Label();
            this.lblKeyNum3 = new System.Windows.Forms.Label();
            this.lblKeyNum2 = new System.Windows.Forms.Label();
            this.lblKeyNum1 = new System.Windows.Forms.Label();
            this.lblKeyNumLock = new System.Windows.Forms.Label();
            this.lblKeyShift = new System.Windows.Forms.Label();
            this.lblKeyCtrl = new System.Windows.Forms.Label();
            this.lblKeyAlt = new System.Windows.Forms.Label();
            this.gbNumLock.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(528, 395);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Instructions:";
            // 
            // lvPressedKeys
            // 
            this.lvPressedKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvPressedKeys.FullRowSelect = true;
            this.lvPressedKeys.GridLines = true;
            this.lvPressedKeys.HideSelection = false;
            this.lvPressedKeys.Location = new System.Drawing.Point(12, 410);
            this.lvPressedKeys.MultiSelect = false;
            this.lvPressedKeys.Name = "lvPressedKeys";
            this.lvPressedKeys.Size = new System.Drawing.Size(528, 245);
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
            this.gbNumLock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNumLock.Controls.Add(this.chkIgnoreFakeShift);
            this.gbNumLock.Controls.Add(this.rbNumLockIgnore);
            this.gbNumLock.Controls.Add(this.rbNumLockShifted);
            this.gbNumLock.Controls.Add(this.rbNumLockDefault);
            this.gbNumLock.Location = new System.Drawing.Point(546, 9);
            this.gbNumLock.Name = "gbNumLock";
            this.gbNumLock.Size = new System.Drawing.Size(542, 395);
            this.gbNumLock.TabIndex = 2;
            this.gbNumLock.TabStop = false;
            this.gbNumLock.Text = "Shift + Numeric Keypad Handling";
            // 
            // chkIgnoreFakeShift
            // 
            this.chkIgnoreFakeShift.Location = new System.Drawing.Point(17, 343);
            this.chkIgnoreFakeShift.Name = "chkIgnoreFakeShift";
            this.chkIgnoreFakeShift.Size = new System.Drawing.Size(300, 31);
            this.chkIgnoreFakeShift.TabIndex = 6;
            this.chkIgnoreFakeShift.Text = "Ignore fake shift keypresses";
            this.chkIgnoreFakeShift.UseVisualStyleBackColor = true;
            this.chkIgnoreFakeShift.CheckedChanged += new System.EventHandler(this.chkIgnoreFakeShift_CheckedChanged);
            // 
            // rbNumLockIgnore
            // 
            this.rbNumLockIgnore.Location = new System.Drawing.Point(17, 237);
            this.rbNumLockIgnore.Name = "rbNumLockIgnore";
            this.rbNumLockIgnore.Size = new System.Drawing.Size(375, 100);
            this.rbNumLockIgnore.TabIndex = 5;
            this.rbNumLockIgnore.Text = "Ignore Shift:\r\nInstead of unshifting the number key back to Home/End/Arrows, trig" +
    "ger a number key without shift";
            this.rbNumLockIgnore.UseVisualStyleBackColor = true;
            this.rbNumLockIgnore.CheckedChanged += new System.EventHandler(this.rbNumLockIgnore_CheckedChanged);
            // 
            // rbNumLockShifted
            // 
            this.rbNumLockShifted.Location = new System.Drawing.Point(17, 131);
            this.rbNumLockShifted.Name = "rbNumLockShifted";
            this.rbNumLockShifted.Size = new System.Drawing.Size(375, 100);
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
            this.rbNumLockDefault.Size = new System.Drawing.Size(375, 100);
            this.rbNumLockDefault.TabIndex = 0;
            this.rbNumLockDefault.TabStop = true;
            this.rbNumLockDefault.Text = "Standard Windows behaviour (unshift):\r\nFake unshift, trigger keypress, fake shift" +
    "\r\nTreat as if numlock is off and shift is not held down";
            this.rbNumLockDefault.UseVisualStyleBackColor = true;
            this.rbNumLockDefault.CheckedChanged += new System.EventHandler(this.rbNumLockDefault_CheckedChanged);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(546, 661);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(542, 151);
            this.txtLog.TabIndex = 3;
            // 
            // txtRawLog
            // 
            this.txtRawLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRawLog.Location = new System.Drawing.Point(12, 661);
            this.txtRawLog.Multiline = true;
            this.txtRawLog.Name = "txtRawLog";
            this.txtRawLog.ReadOnly = true;
            this.txtRawLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRawLog.Size = new System.Drawing.Size(528, 151);
            this.txtRawLog.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28769F));
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNumLock, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum6, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum5, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyPgUp, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyHome, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyIns, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyDel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyEnd, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyPgDn, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyLeft, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyDown, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyRight, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyUp, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum4, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum9, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum1, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum2, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum3, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNum0, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyNumDecimal, 8, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyCtrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyShift, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyAlt, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(546, 410);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 245);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblKeyIns
            // 
            this.lblKeyIns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyIns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyIns.Location = new System.Drawing.Point(96, 5);
            this.lblKeyIns.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyIns.Name = "lblKeyIns";
            this.lblKeyIns.Size = new System.Drawing.Size(61, 51);
            this.lblKeyIns.TabIndex = 0;
            // 
            // lblKeyHome
            // 
            this.lblKeyHome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyHome.Location = new System.Drawing.Point(167, 5);
            this.lblKeyHome.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyHome.Name = "lblKeyHome";
            this.lblKeyHome.Size = new System.Drawing.Size(61, 51);
            this.lblKeyHome.TabIndex = 1;
            // 
            // lblKeyPgUp
            // 
            this.lblKeyPgUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyPgUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyPgUp.Location = new System.Drawing.Point(238, 5);
            this.lblKeyPgUp.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyPgUp.Name = "lblKeyPgUp";
            this.lblKeyPgUp.Size = new System.Drawing.Size(61, 51);
            this.lblKeyPgUp.TabIndex = 2;
            // 
            // lblKeyDel
            // 
            this.lblKeyDel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyDel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyDel.Location = new System.Drawing.Point(96, 66);
            this.lblKeyDel.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyDel.Name = "lblKeyDel";
            this.lblKeyDel.Size = new System.Drawing.Size(61, 51);
            this.lblKeyDel.TabIndex = 3;
            // 
            // lblKeyEnd
            // 
            this.lblKeyEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyEnd.Location = new System.Drawing.Point(167, 66);
            this.lblKeyEnd.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyEnd.Name = "lblKeyEnd";
            this.lblKeyEnd.Size = new System.Drawing.Size(61, 51);
            this.lblKeyEnd.TabIndex = 4;
            // 
            // lblKeyPgDn
            // 
            this.lblKeyPgDn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyPgDn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyPgDn.Location = new System.Drawing.Point(238, 66);
            this.lblKeyPgDn.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyPgDn.Name = "lblKeyPgDn";
            this.lblKeyPgDn.Size = new System.Drawing.Size(61, 51);
            this.lblKeyPgDn.TabIndex = 5;
            // 
            // lblKeyUp
            // 
            this.lblKeyUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyUp.Location = new System.Drawing.Point(167, 127);
            this.lblKeyUp.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyUp.Name = "lblKeyUp";
            this.lblKeyUp.Size = new System.Drawing.Size(61, 51);
            this.lblKeyUp.TabIndex = 6;
            // 
            // lblKeyLeft
            // 
            this.lblKeyLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyLeft.Location = new System.Drawing.Point(96, 188);
            this.lblKeyLeft.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyLeft.Name = "lblKeyLeft";
            this.lblKeyLeft.Size = new System.Drawing.Size(61, 52);
            this.lblKeyLeft.TabIndex = 7;
            // 
            // lblKeyDown
            // 
            this.lblKeyDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyDown.Location = new System.Drawing.Point(167, 188);
            this.lblKeyDown.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyDown.Name = "lblKeyDown";
            this.lblKeyDown.Size = new System.Drawing.Size(61, 52);
            this.lblKeyDown.TabIndex = 8;
            // 
            // lblKeyRight
            // 
            this.lblKeyRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyRight.Location = new System.Drawing.Point(238, 188);
            this.lblKeyRight.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyRight.Name = "lblKeyRight";
            this.lblKeyRight.Size = new System.Drawing.Size(61, 52);
            this.lblKeyRight.TabIndex = 9;
            // 
            // lblKeyNum7
            // 
            this.lblKeyNum7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum7.Location = new System.Drawing.Point(329, 5);
            this.lblKeyNum7.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum7.Name = "lblKeyNum7";
            this.lblKeyNum7.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum7.TabIndex = 10;
            // 
            // lblKeyNum4
            // 
            this.lblKeyNum4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum4.Location = new System.Drawing.Point(329, 66);
            this.lblKeyNum4.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum4.Name = "lblKeyNum4";
            this.lblKeyNum4.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum4.TabIndex = 11;
            // 
            // lblKeyNum8
            // 
            this.lblKeyNum8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum8.Location = new System.Drawing.Point(400, 5);
            this.lblKeyNum8.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum8.Name = "lblKeyNum8";
            this.lblKeyNum8.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum8.TabIndex = 12;
            // 
            // lblKeyNum9
            // 
            this.lblKeyNum9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum9.Location = new System.Drawing.Point(471, 5);
            this.lblKeyNum9.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum9.Name = "lblKeyNum9";
            this.lblKeyNum9.Size = new System.Drawing.Size(66, 51);
            this.lblKeyNum9.TabIndex = 13;
            // 
            // lblKeyNumDecimal
            // 
            this.lblKeyNumDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNumDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNumDecimal.Location = new System.Drawing.Point(471, 188);
            this.lblKeyNumDecimal.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNumDecimal.Name = "lblKeyNumDecimal";
            this.lblKeyNumDecimal.Size = new System.Drawing.Size(66, 52);
            this.lblKeyNumDecimal.TabIndex = 14;
            // 
            // lblKeyNum0
            // 
            this.lblKeyNum0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.lblKeyNum0, 2);
            this.lblKeyNum0.Location = new System.Drawing.Point(329, 188);
            this.lblKeyNum0.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum0.Name = "lblKeyNum0";
            this.lblKeyNum0.Size = new System.Drawing.Size(132, 52);
            this.lblKeyNum0.TabIndex = 15;
            // 
            // lblKeyNum5
            // 
            this.lblKeyNum5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum5.Location = new System.Drawing.Point(400, 66);
            this.lblKeyNum5.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum5.Name = "lblKeyNum5";
            this.lblKeyNum5.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum5.TabIndex = 16;
            // 
            // lblKeyNum6
            // 
            this.lblKeyNum6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum6.Location = new System.Drawing.Point(471, 66);
            this.lblKeyNum6.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum6.Name = "lblKeyNum6";
            this.lblKeyNum6.Size = new System.Drawing.Size(66, 51);
            this.lblKeyNum6.TabIndex = 17;
            // 
            // lblKeyNum3
            // 
            this.lblKeyNum3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum3.Location = new System.Drawing.Point(471, 127);
            this.lblKeyNum3.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum3.Name = "lblKeyNum3";
            this.lblKeyNum3.Size = new System.Drawing.Size(66, 51);
            this.lblKeyNum3.TabIndex = 18;
            // 
            // lblKeyNum2
            // 
            this.lblKeyNum2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum2.Location = new System.Drawing.Point(400, 127);
            this.lblKeyNum2.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum2.Name = "lblKeyNum2";
            this.lblKeyNum2.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum2.TabIndex = 19;
            // 
            // lblKeyNum1
            // 
            this.lblKeyNum1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNum1.Location = new System.Drawing.Point(329, 127);
            this.lblKeyNum1.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNum1.Name = "lblKeyNum1";
            this.lblKeyNum1.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNum1.TabIndex = 20;
            // 
            // lblKeyNumLock
            // 
            this.lblKeyNumLock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyNumLock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyNumLock.Location = new System.Drawing.Point(5, 5);
            this.lblKeyNumLock.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyNumLock.Name = "lblKeyNumLock";
            this.lblKeyNumLock.Size = new System.Drawing.Size(61, 51);
            this.lblKeyNumLock.TabIndex = 21;
            // 
            // lblKeyShift
            // 
            this.lblKeyShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyShift.Location = new System.Drawing.Point(5, 188);
            this.lblKeyShift.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyShift.Name = "lblKeyShift";
            this.lblKeyShift.Size = new System.Drawing.Size(61, 52);
            this.lblKeyShift.TabIndex = 22;
            // 
            // lblKeyCtrl
            // 
            this.lblKeyCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyCtrl.Location = new System.Drawing.Point(5, 66);
            this.lblKeyCtrl.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyCtrl.Name = "lblKeyCtrl";
            this.lblKeyCtrl.Size = new System.Drawing.Size(61, 51);
            this.lblKeyCtrl.TabIndex = 23;
            // 
            // lblKeyAlt
            // 
            this.lblKeyAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyAlt.Location = new System.Drawing.Point(5, 127);
            this.lblKeyAlt.Margin = new System.Windows.Forms.Padding(5);
            this.lblKeyAlt.Name = "lblKeyAlt";
            this.lblKeyAlt.Size = new System.Drawing.Size(61, 51);
            this.lblKeyAlt.TabIndex = 24;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 821);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtRawLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gbNumLock);
            this.Controls.Add(this.lvPressedKeys);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Tester";
            this.gbNumLock.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chkIgnoreFakeShift;
        private System.Windows.Forms.TextBox txtRawLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKeyNum6;
        private System.Windows.Forms.Label lblKeyNum5;
        private System.Windows.Forms.Label lblKeyPgUp;
        private System.Windows.Forms.Label lblKeyHome;
        private System.Windows.Forms.Label lblKeyIns;
        private System.Windows.Forms.Label lblKeyDel;
        private System.Windows.Forms.Label lblKeyEnd;
        private System.Windows.Forms.Label lblKeyPgDn;
        private System.Windows.Forms.Label lblKeyLeft;
        private System.Windows.Forms.Label lblKeyDown;
        private System.Windows.Forms.Label lblKeyRight;
        private System.Windows.Forms.Label lblKeyUp;
        private System.Windows.Forms.Label lblKeyNum7;
        private System.Windows.Forms.Label lblKeyNum4;
        private System.Windows.Forms.Label lblKeyNum8;
        private System.Windows.Forms.Label lblKeyNum9;
        private System.Windows.Forms.Label lblKeyNum1;
        private System.Windows.Forms.Label lblKeyNum2;
        private System.Windows.Forms.Label lblKeyNum3;
        private System.Windows.Forms.Label lblKeyNum0;
        private System.Windows.Forms.Label lblKeyNumDecimal;
        private System.Windows.Forms.Label lblKeyNumLock;
        private System.Windows.Forms.Label lblKeyShift;
        private System.Windows.Forms.Label lblKeyCtrl;
        private System.Windows.Forms.Label lblKeyAlt;
    }
}

