﻿namespace MiniDraw
{
    partial class DrawingOptions
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
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.disableListCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.controlGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.customLineTypes = new System.Windows.Forms.ListBox();
            this.customColorsLabel = new System.Windows.Forms.Label();
            this.solidRadioButton = new System.Windows.Forms.RadioButton();
            this.dashedRadioButton = new System.Windows.Forms.RadioButton();
            this.lineTypeGroup = new System.Windows.Forms.GroupBox();
            this.dashDotRadioButton = new System.Windows.Forms.RadioButton();
            this.dottedRadioButton = new System.Windows.Forms.RadioButton();
            this.lineWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.controlGroupBox.SuspendLayout();
            this.lineTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Location = new System.Drawing.Point(54, 29);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(120, 44);
            this.chooseColorButton.TabIndex = 0;
            this.chooseColorButton.Text = "Choose Line Color";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // disableListCheckBox
            // 
            this.disableListCheckBox.AutoSize = true;
            this.disableListCheckBox.Checked = true;
            this.disableListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableListCheckBox.Location = new System.Drawing.Point(63, 277);
            this.disableListCheckBox.Name = "disableListCheckBox";
            this.disableListCheckBox.Size = new System.Drawing.Size(98, 21);
            this.disableListCheckBox.TabIndex = 1;
            this.disableListCheckBox.Text = "Disable list";
            this.disableListCheckBox.UseVisualStyleBackColor = true;
            this.disableListCheckBox.CheckedChanged += new System.EventHandler(this.disableListCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(29, 36);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(120, 44);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // controlGroupBox
            // 
            this.controlGroupBox.Controls.Add(this.okButton);
            this.controlGroupBox.Controls.Add(this.cancelButton);
            this.controlGroupBox.Location = new System.Drawing.Point(214, 203);
            this.controlGroupBox.Name = "controlGroupBox";
            this.controlGroupBox.Size = new System.Drawing.Size(175, 171);
            this.controlGroupBox.TabIndex = 4;
            this.controlGroupBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(29, 97);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 44);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // customLineTypes
            // 
            this.customLineTypes.FormattingEnabled = true;
            this.customLineTypes.HorizontalScrollbar = true;
            this.customLineTypes.ItemHeight = 16;
            this.customLineTypes.Location = new System.Drawing.Point(33, 130);
            this.customLineTypes.Name = "customLineTypes";
            this.customLineTypes.Size = new System.Drawing.Size(156, 132);
            this.customLineTypes.TabIndex = 5;
            // 
            // customColorsLabel
            // 
            this.customColorsLabel.AutoSize = true;
            this.customColorsLabel.Location = new System.Drawing.Point(51, 97);
            this.customColorsLabel.Name = "customColorsLabel";
            this.customColorsLabel.Size = new System.Drawing.Size(111, 17);
            this.customColorsLabel.TabIndex = 7;
            this.customColorsLabel.Text = "Latest line types";
            // 
            // solidRadioButton
            // 
            this.solidRadioButton.AutoSize = true;
            this.solidRadioButton.Checked = true;
            this.solidRadioButton.Location = new System.Drawing.Point(15, 37);
            this.solidRadioButton.Name = "solidRadioButton";
            this.solidRadioButton.Size = new System.Drawing.Size(60, 21);
            this.solidRadioButton.TabIndex = 8;
            this.solidRadioButton.TabStop = true;
            this.solidRadioButton.Text = "Solid";
            this.solidRadioButton.UseVisualStyleBackColor = true;
            // 
            // dashedRadioButton
            // 
            this.dashedRadioButton.AutoSize = true;
            this.dashedRadioButton.Location = new System.Drawing.Point(15, 64);
            this.dashedRadioButton.Name = "dashedRadioButton";
            this.dashedRadioButton.Size = new System.Drawing.Size(78, 21);
            this.dashedRadioButton.TabIndex = 9;
            this.dashedRadioButton.Text = "Dashed";
            this.dashedRadioButton.UseVisualStyleBackColor = true;
            // 
            // lineTypeGroup
            // 
            this.lineTypeGroup.Controls.Add(this.dashDotRadioButton);
            this.lineTypeGroup.Controls.Add(this.dottedRadioButton);
            this.lineTypeGroup.Controls.Add(this.solidRadioButton);
            this.lineTypeGroup.Controls.Add(this.dashedRadioButton);
            this.lineTypeGroup.Location = new System.Drawing.Point(231, 29);
            this.lineTypeGroup.Name = "lineTypeGroup";
            this.lineTypeGroup.Size = new System.Drawing.Size(142, 168);
            this.lineTypeGroup.TabIndex = 10;
            this.lineTypeGroup.TabStop = false;
            this.lineTypeGroup.Text = "Line Type";
            // 
            // dashDotRadioButton
            // 
            this.dashDotRadioButton.AutoSize = true;
            this.dashDotRadioButton.Location = new System.Drawing.Point(15, 118);
            this.dashDotRadioButton.Name = "dashDotRadioButton";
            this.dashDotRadioButton.Size = new System.Drawing.Size(109, 21);
            this.dashDotRadioButton.TabIndex = 11;
            this.dashDotRadioButton.Text = "Dash-Dotted";
            this.dashDotRadioButton.UseVisualStyleBackColor = true;
            // 
            // dottedRadioButton
            // 
            this.dottedRadioButton.AutoSize = true;
            this.dottedRadioButton.Location = new System.Drawing.Point(15, 91);
            this.dottedRadioButton.Name = "dottedRadioButton";
            this.dottedRadioButton.Size = new System.Drawing.Size(71, 21);
            this.dottedRadioButton.TabIndex = 10;
            this.dottedRadioButton.Text = "Dotted";
            this.dottedRadioButton.UseVisualStyleBackColor = true;
            // 
            // lineWidthNumericUpDown
            // 
            this.lineWidthNumericUpDown.DecimalPlaces = 1;
            this.lineWidthNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lineWidthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lineWidthNumericUpDown.Location = new System.Drawing.Point(54, 352);
            this.lineWidthNumericUpDown.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.lineWidthNumericUpDown.Name = "lineWidthNumericUpDown";
            this.lineWidthNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.lineWidthNumericUpDown.TabIndex = 11;
            this.lineWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lineWidthNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Line Width";
            // 
            // DrawingOptions
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(415, 403);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineWidthNumericUpDown);
            this.Controls.Add(this.lineTypeGroup);
            this.Controls.Add(this.customColorsLabel);
            this.Controls.Add(this.customLineTypes);
            this.Controls.Add(this.controlGroupBox);
            this.Controls.Add(this.disableListCheckBox);
            this.Controls.Add(this.chooseColorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawingOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drawing Options";
            this.controlGroupBox.ResumeLayout(false);
            this.lineTypeGroup.ResumeLayout(false);
            this.lineTypeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.CheckBox disableListCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox controlGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox customLineTypes;
        private System.Windows.Forms.Label customColorsLabel;
        private System.Windows.Forms.RadioButton solidRadioButton;
        private System.Windows.Forms.RadioButton dashedRadioButton;
        private System.Windows.Forms.GroupBox lineTypeGroup;
        private System.Windows.Forms.RadioButton dottedRadioButton;
        private System.Windows.Forms.NumericUpDown lineWidthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton dashDotRadioButton;
    }
}