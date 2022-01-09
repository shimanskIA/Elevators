namespace Lab2GUI
{
    partial class CreatePeopleView
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AmountField = new System.Windows.Forms.TextBox();
            this.GStageField = new System.Windows.Forms.TextBox();
            this.AimStageField = new System.Windows.Forms.TextBox();
            this.Generate_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.AverageWeightField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amount Of People:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "Generation Stage:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "Aim Stage:";
            // 
            // AmountField
            // 
            this.AmountField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountField.Location = new System.Drawing.Point(255, 9);
            this.AmountField.Multiline = true;
            this.AmountField.Name = "AmountField";
            this.AmountField.Size = new System.Drawing.Size(136, 29);
            this.AmountField.TabIndex = 17;
            this.AmountField.TextChanged += new System.EventHandler(this.AmountField_TextChanged);
            // 
            // GStageField
            // 
            this.GStageField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GStageField.Location = new System.Drawing.Point(243, 48);
            this.GStageField.Multiline = true;
            this.GStageField.Name = "GStageField";
            this.GStageField.Size = new System.Drawing.Size(136, 29);
            this.GStageField.TabIndex = 18;
            this.GStageField.TextChanged += new System.EventHandler(this.GStageField_TextChanged);
            // 
            // AimStageField
            // 
            this.AimStageField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AimStageField.Location = new System.Drawing.Point(159, 88);
            this.AimStageField.Multiline = true;
            this.AimStageField.Name = "AimStageField";
            this.AimStageField.Size = new System.Drawing.Size(136, 29);
            this.AimStageField.TabIndex = 19;
            this.AimStageField.TextChanged += new System.EventHandler(this.AimStageField_TextChanged);
            // 
            // Generate_button
            // 
            this.Generate_button.BackColor = System.Drawing.Color.Red;
            this.Generate_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generate_button.Location = new System.Drawing.Point(124, 187);
            this.Generate_button.Name = "Generate_button";
            this.Generate_button.Size = new System.Drawing.Size(171, 72);
            this.Generate_button.TabIndex = 20;
            this.Generate_button.Text = "Generate";
            this.Generate_button.UseVisualStyleBackColor = false;
            this.Generate_button.Click += new System.EventHandler(this.Generate_button_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Warning:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Average Weight:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // AverageWeightField
            // 
            this.AverageWeightField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AverageWeightField.Location = new System.Drawing.Point(229, 129);
            this.AverageWeightField.Multiline = true;
            this.AverageWeightField.Name = "AverageWeightField";
            this.AverageWeightField.Size = new System.Drawing.Size(136, 29);
            this.AverageWeightField.TabIndex = 22;
            // 
            // CreatePeopleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 276);
            this.Controls.Add(this.AverageWeightField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Generate_button);
            this.Controls.Add(this.AimStageField);
            this.Controls.Add(this.GStageField);
            this.Controls.Add(this.AmountField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePeopleView";
            this.Text = "Create People";
            this.toolTip1.SetToolTip(this, "To activate \"Generate\" button, all the fields must be set");
            this.Load += new System.EventHandler(this.CreatePeopleView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AmountField;
        private System.Windows.Forms.TextBox GStageField;
        private System.Windows.Forms.TextBox AimStageField;
        private System.Windows.Forms.Button Generate_button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AverageWeightField;
    }
}