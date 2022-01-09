namespace Lab2GUI
{
    partial class SetRuleView
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FixedGen_RB = new System.Windows.Forms.RadioButton();
            this.RandomGen_RB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeFieldLeft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountFieldLeft = new System.Windows.Forms.TextBox();
            this.GStageFieldLeft = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AimStageFieldLeft = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RuleNameFieldLeft = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TimeFieldRight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.AmountFieldRight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GStageFieldRight = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AimStageFieldRight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.IntervalField = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RuleNameFieldRight = new System.Windows.Forms.TextBox();
            this.ImportRule_button = new System.Windows.Forms.Button();
            this.ExportRule_button = new System.Windows.Forms.Button();
            this.AcceptNExit_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.AverageWeightFieldLeft = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.AverageWeightFieldRight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 66);
            this.label2.TabIndex = 5;
            this.label2.Text = "Random Interval Generation: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(671, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 66);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fixed Interval Generation:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FixedGen_RB
            // 
            this.FixedGen_RB.AutoSize = true;
            this.FixedGen_RB.Location = new System.Drawing.Point(821, 78);
            this.FixedGen_RB.Name = "FixedGen_RB";
            this.FixedGen_RB.Size = new System.Drawing.Size(17, 16);
            this.FixedGen_RB.TabIndex = 7;
            this.FixedGen_RB.TabStop = true;
            this.FixedGen_RB.UseVisualStyleBackColor = true;
            this.FixedGen_RB.CheckedChanged += new System.EventHandler(this.FixedGen_RB_CheckedChanged);
            // 
            // RandomGen_RB
            // 
            this.RandomGen_RB.AutoSize = true;
            this.RandomGen_RB.Location = new System.Drawing.Point(82, 78);
            this.RandomGen_RB.Name = "RandomGen_RB";
            this.RandomGen_RB.Size = new System.Drawing.Size(17, 16);
            this.RandomGen_RB.TabIndex = 8;
            this.RandomGen_RB.TabStop = true;
            this.RandomGen_RB.UseVisualStyleBackColor = true;
            this.RandomGen_RB.CheckedChanged += new System.EventHandler(this.RandomGen_RB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Time:";
            // 
            // TimeFieldLeft
            // 
            this.TimeFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeFieldLeft.Location = new System.Drawing.Point(102, 120);
            this.TimeFieldLeft.Multiline = true;
            this.TimeFieldLeft.Name = "TimeFieldLeft";
            this.TimeFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.TimeFieldLeft.TabIndex = 10;
            this.TimeFieldLeft.TextChanged += new System.EventHandler(this.TimeFieldLeft_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Amount Of People:";
            // 
            // AmountFieldLeft
            // 
            this.AmountFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountFieldLeft.Location = new System.Drawing.Point(261, 163);
            this.AmountFieldLeft.Multiline = true;
            this.AmountFieldLeft.Name = "AmountFieldLeft";
            this.AmountFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.AmountFieldLeft.TabIndex = 12;
            this.AmountFieldLeft.TextChanged += new System.EventHandler(this.AmountFieldLeft_TextChanged);
            // 
            // GStageFieldLeft
            // 
            this.GStageFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GStageFieldLeft.Location = new System.Drawing.Point(252, 207);
            this.GStageFieldLeft.Multiline = true;
            this.GStageFieldLeft.Name = "GStageFieldLeft";
            this.GStageFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.GStageFieldLeft.TabIndex = 13;
            this.GStageFieldLeft.TextChanged += new System.EventHandler(this.GStageFieldLeft_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Generation Stage:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Aim Stage:";
            // 
            // AimStageFieldLeft
            // 
            this.AimStageFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AimStageFieldLeft.Location = new System.Drawing.Point(159, 250);
            this.AimStageFieldLeft.Multiline = true;
            this.AimStageFieldLeft.Name = "AimStageFieldLeft";
            this.AimStageFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.AimStageFieldLeft.TabIndex = 16;
            this.AimStageFieldLeft.TextChanged += new System.EventHandler(this.AimStageFieldLeft_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 29);
            this.label7.TabIndex = 17;
            this.label7.Text = "Rule Name:";
            // 
            // RuleNameFieldLeft
            // 
            this.RuleNameFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RuleNameFieldLeft.Location = new System.Drawing.Point(172, 335);
            this.RuleNameFieldLeft.Multiline = true;
            this.RuleNameFieldLeft.Name = "RuleNameFieldLeft";
            this.RuleNameFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.RuleNameFieldLeft.TabIndex = 18;
            this.RuleNameFieldLeft.TextChanged += new System.EventHandler(this.RuleNameFieldLeft_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(528, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 29);
            this.label8.TabIndex = 19;
            this.label8.Text = "Start Time:";
            // 
            // TimeFieldRight
            // 
            this.TimeFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeFieldRight.Location = new System.Drawing.Point(678, 120);
            this.TimeFieldRight.Multiline = true;
            this.TimeFieldRight.Name = "TimeFieldRight";
            this.TimeFieldRight.Size = new System.Drawing.Size(136, 29);
            this.TimeFieldRight.TabIndex = 20;
            this.TimeFieldRight.TextChanged += new System.EventHandler(this.TimeFieldRight_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(528, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 29);
            this.label9.TabIndex = 21;
            this.label9.Text = "Amount Of People:";
            // 
            // AmountFieldRight
            // 
            this.AmountFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountFieldRight.Location = new System.Drawing.Point(771, 155);
            this.AmountFieldRight.Multiline = true;
            this.AmountFieldRight.Name = "AmountFieldRight";
            this.AmountFieldRight.Size = new System.Drawing.Size(136, 29);
            this.AmountFieldRight.TabIndex = 22;
            this.AmountFieldRight.TextChanged += new System.EventHandler(this.AmountFieldRight_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(528, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 29);
            this.label10.TabIndex = 23;
            this.label10.Text = "Generation Stage:";
            // 
            // GStageFieldRight
            // 
            this.GStageFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GStageFieldRight.Location = new System.Drawing.Point(759, 204);
            this.GStageFieldRight.Multiline = true;
            this.GStageFieldRight.Name = "GStageFieldRight";
            this.GStageFieldRight.Size = new System.Drawing.Size(136, 29);
            this.GStageFieldRight.TabIndex = 24;
            this.GStageFieldRight.TextChanged += new System.EventHandler(this.GStageFieldRight_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(528, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 29);
            this.label11.TabIndex = 25;
            this.label11.Text = "Aim Stage:";
            // 
            // AimStageFieldRight
            // 
            this.AimStageFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AimStageFieldRight.Location = new System.Drawing.Point(675, 244);
            this.AimStageFieldRight.Multiline = true;
            this.AimStageFieldRight.Name = "AimStageFieldRight";
            this.AimStageFieldRight.Size = new System.Drawing.Size(136, 29);
            this.AimStageFieldRight.TabIndex = 26;
            this.AimStageFieldRight.TextChanged += new System.EventHandler(this.AimStageFieldRight_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(528, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 29);
            this.label12.TabIndex = 27;
            this.label12.Text = "Interval:";
            // 
            // IntervalField
            // 
            this.IntervalField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IntervalField.Location = new System.Drawing.Point(649, 292);
            this.IntervalField.Multiline = true;
            this.IntervalField.Name = "IntervalField";
            this.IntervalField.Size = new System.Drawing.Size(136, 29);
            this.IntervalField.TabIndex = 28;
            this.IntervalField.TextChanged += new System.EventHandler(this.IntervalField_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(528, 377);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 29);
            this.label13.TabIndex = 29;
            this.label13.Text = "Rule Name:";
            // 
            // RuleNameFieldRight
            // 
            this.RuleNameFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RuleNameFieldRight.Location = new System.Drawing.Point(688, 377);
            this.RuleNameFieldRight.Multiline = true;
            this.RuleNameFieldRight.Name = "RuleNameFieldRight";
            this.RuleNameFieldRight.Size = new System.Drawing.Size(136, 29);
            this.RuleNameFieldRight.TabIndex = 30;
            this.RuleNameFieldRight.TextChanged += new System.EventHandler(this.RuleNameFieldRight_TextChanged);
            // 
            // ImportRule_button
            // 
            this.ImportRule_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ImportRule_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportRule_button.Location = new System.Drawing.Point(17, 451);
            this.ImportRule_button.Name = "ImportRule_button";
            this.ImportRule_button.Size = new System.Drawing.Size(171, 72);
            this.ImportRule_button.TabIndex = 31;
            this.ImportRule_button.Text = "Import Rule";
            this.ImportRule_button.UseVisualStyleBackColor = false;
            this.ImportRule_button.Click += new System.EventHandler(this.ImportRule_button_Click);
            // 
            // ExportRule_button
            // 
            this.ExportRule_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExportRule_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportRule_button.Location = new System.Drawing.Point(189, 451);
            this.ExportRule_button.Name = "ExportRule_button";
            this.ExportRule_button.Size = new System.Drawing.Size(171, 72);
            this.ExportRule_button.TabIndex = 32;
            this.ExportRule_button.Text = "Export Rule";
            this.ExportRule_button.UseVisualStyleBackColor = false;
            this.ExportRule_button.Click += new System.EventHandler(this.ExportRule_button_Click);
            // 
            // AcceptNExit_button
            // 
            this.AcceptNExit_button.BackColor = System.Drawing.Color.Red;
            this.AcceptNExit_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptNExit_button.Location = new System.Drawing.Point(688, 451);
            this.AcceptNExit_button.Name = "AcceptNExit_button";
            this.AcceptNExit_button.Size = new System.Drawing.Size(207, 72);
            this.AcceptNExit_button.TabIndex = 33;
            this.AcceptNExit_button.Text = "Accept and Exit";
            this.AcceptNExit_button.UseVisualStyleBackColor = false;
            this.AcceptNExit_button.Click += new System.EventHandler(this.AcceptNExit_button_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Warning: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 292);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(211, 29);
            this.label14.TabIndex = 34;
            this.label14.Text = "Average Weight:";
            this.label14.Click += new System.EventHandler(this.Label14_Click);
            // 
            // AverageWeightFieldLeft
            // 
            this.AverageWeightFieldLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageWeightFieldLeft.Location = new System.Drawing.Point(229, 292);
            this.AverageWeightFieldLeft.Multiline = true;
            this.AverageWeightFieldLeft.Name = "AverageWeightFieldLeft";
            this.AverageWeightFieldLeft.Size = new System.Drawing.Size(136, 29);
            this.AverageWeightFieldLeft.TabIndex = 35;
            this.AverageWeightFieldLeft.TextChanged += new System.EventHandler(this.AverageWeightFieldLeft_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(528, 335);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(211, 29);
            this.label15.TabIndex = 36;
            this.label15.Text = "Average Weight:";
            // 
            // AverageWeightFieldRight
            // 
            this.AverageWeightFieldRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageWeightFieldRight.Location = new System.Drawing.Point(745, 335);
            this.AverageWeightFieldRight.Multiline = true;
            this.AverageWeightFieldRight.Name = "AverageWeightFieldRight";
            this.AverageWeightFieldRight.Size = new System.Drawing.Size(136, 29);
            this.AverageWeightFieldRight.TabIndex = 37;
            this.AverageWeightFieldRight.TextChanged += new System.EventHandler(this.AverageWeightFieldRight_TextChanged);
            // 
            // SetRuleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 535);
            this.Controls.Add(this.AverageWeightFieldRight);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.AverageWeightFieldLeft);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.AcceptNExit_button);
            this.Controls.Add(this.ExportRule_button);
            this.Controls.Add(this.ImportRule_button);
            this.Controls.Add(this.RuleNameFieldRight);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.IntervalField);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AimStageFieldRight);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GStageFieldRight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AmountFieldRight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TimeFieldRight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RuleNameFieldLeft);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AimStageFieldLeft);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GStageFieldLeft);
            this.Controls.Add(this.AmountFieldLeft);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeFieldLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RandomGen_RB);
            this.Controls.Add(this.FixedGen_RB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetRuleView";
            this.Text = "Set Rule";
            this.toolTip1.SetToolTip(this, "To activate \"Accept and Exit\" button, all the fields must be set");
            this.Load += new System.EventHandler(this.SetRuleView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton FixedGen_RB;
        private System.Windows.Forms.RadioButton RandomGen_RB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TimeFieldLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AmountFieldLeft;
        private System.Windows.Forms.TextBox GStageFieldLeft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AimStageFieldLeft;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RuleNameFieldLeft;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TimeFieldRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox AmountFieldRight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GStageFieldRight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AimStageFieldRight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox IntervalField;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox RuleNameFieldRight;
        private System.Windows.Forms.Button ImportRule_button;
        private System.Windows.Forms.Button ExportRule_button;
        private System.Windows.Forms.Button AcceptNExit_button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox AverageWeightFieldLeft;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox AverageWeightFieldRight;
    }
}