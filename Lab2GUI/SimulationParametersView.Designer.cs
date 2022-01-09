namespace Lab2GUI
{
    partial class SimulationParametersView
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HeightField = new System.Windows.Forms.TextBox();
            this.ElNumberField = new System.Windows.Forms.TextBox();
            this.ElCapacityField = new System.Windows.Forms.TextBox();
            this.ImportParameters_button = new System.Windows.Forms.Button();
            this.ExportParameters_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Mode1_RB = new System.Windows.Forms.RadioButton();
            this.Mode2_RB = new System.Windows.Forms.RadioButton();
            this.Mode3_RB = new System.Windows.Forms.RadioButton();
            this.StartSimulation_button = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Elevators Number:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Elevators Capacity:";
            // 
            // HeightField
            // 
            this.HeightField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeightField.Location = new System.Drawing.Point(121, 9);
            this.HeightField.Multiline = true;
            this.HeightField.Name = "HeightField";
            this.HeightField.Size = new System.Drawing.Size(136, 29);
            this.HeightField.TabIndex = 13;
            this.HeightField.TextChanged += new System.EventHandler(this.HeightField_TextChanged);
            // 
            // ElNumberField
            // 
            this.ElNumberField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElNumberField.Location = new System.Drawing.Point(263, 47);
            this.ElNumberField.Multiline = true;
            this.ElNumberField.Name = "ElNumberField";
            this.ElNumberField.Size = new System.Drawing.Size(136, 29);
            this.ElNumberField.TabIndex = 14;
            this.ElNumberField.TextChanged += new System.EventHandler(this.ElNumberField_TextChanged);
            // 
            // ElCapacityField
            // 
            this.ElCapacityField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElCapacityField.Location = new System.Drawing.Point(272, 87);
            this.ElCapacityField.Multiline = true;
            this.ElCapacityField.Name = "ElCapacityField";
            this.ElCapacityField.Size = new System.Drawing.Size(136, 29);
            this.ElCapacityField.TabIndex = 15;
            this.ElCapacityField.TextChanged += new System.EventHandler(this.ElCapacityField_TextChanged);
            // 
            // ImportParameters_button
            // 
            this.ImportParameters_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ImportParameters_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportParameters_button.Location = new System.Drawing.Point(12, 157);
            this.ImportParameters_button.Name = "ImportParameters_button";
            this.ImportParameters_button.Size = new System.Drawing.Size(171, 72);
            this.ImportParameters_button.TabIndex = 32;
            this.ImportParameters_button.Text = "Import Parameters";
            this.ImportParameters_button.UseVisualStyleBackColor = false;
            this.ImportParameters_button.Click += new System.EventHandler(this.ImportParameters_button_Click);
            // 
            // ExportParameters_button
            // 
            this.ExportParameters_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExportParameters_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportParameters_button.Location = new System.Drawing.Point(189, 157);
            this.ExportParameters_button.Name = "ExportParameters_button";
            this.ExportParameters_button.Size = new System.Drawing.Size(171, 72);
            this.ExportParameters_button.TabIndex = 33;
            this.ExportParameters_button.Text = "Export Parameters";
            this.ExportParameters_button.UseVisualStyleBackColor = false;
            this.ExportParameters_button.Click += new System.EventHandler(this.ExportParameters_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 29);
            this.label4.TabIndex = 34;
            this.label4.Text = "Modes:";
            // 
            // Mode1_RB
            // 
            this.Mode1_RB.AutoSize = true;
            this.Mode1_RB.Checked = true;
            this.Mode1_RB.Font = new System.Drawing.Font("Rockwell Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode1_RB.Location = new System.Drawing.Point(527, 38);
            this.Mode1_RB.Name = "Mode1_RB";
            this.Mode1_RB.Size = new System.Drawing.Size(90, 33);
            this.Mode1_RB.TabIndex = 35;
            this.Mode1_RB.TabStop = true;
            this.Mode1_RB.Text = "Mode 1";
            this.Mode1_RB.UseVisualStyleBackColor = true;
            this.Mode1_RB.CheckedChanged += new System.EventHandler(this.Mode1_RB_CheckedChanged);
            // 
            // Mode2_RB
            // 
            this.Mode2_RB.AutoSize = true;
            this.Mode2_RB.Font = new System.Drawing.Font("Rockwell Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode2_RB.Location = new System.Drawing.Point(527, 77);
            this.Mode2_RB.Name = "Mode2_RB";
            this.Mode2_RB.Size = new System.Drawing.Size(90, 33);
            this.Mode2_RB.TabIndex = 36;
            this.Mode2_RB.Text = "Mode 2";
            this.Mode2_RB.UseVisualStyleBackColor = true;
            // 
            // Mode3_RB
            // 
            this.Mode3_RB.AutoSize = true;
            this.Mode3_RB.Font = new System.Drawing.Font("Rockwell Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode3_RB.Location = new System.Drawing.Point(527, 116);
            this.Mode3_RB.Name = "Mode3_RB";
            this.Mode3_RB.Size = new System.Drawing.Size(90, 33);
            this.Mode3_RB.TabIndex = 37;
            this.Mode3_RB.Text = "Mode 3";
            this.Mode3_RB.UseVisualStyleBackColor = true;
            // 
            // StartSimulation_button
            // 
            this.StartSimulation_button.BackColor = System.Drawing.Color.Red;
            this.StartSimulation_button.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartSimulation_button.Location = new System.Drawing.Point(474, 157);
            this.StartSimulation_button.Name = "StartSimulation_button";
            this.StartSimulation_button.Size = new System.Drawing.Size(171, 72);
            this.StartSimulation_button.TabIndex = 38;
            this.StartSimulation_button.Text = "Start Simulation";
            this.StartSimulation_button.UseVisualStyleBackColor = false;
            this.StartSimulation_button.Click += new System.EventHandler(this.StartSimulation_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Warning:";
            // 
            // SimulationParametersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 253);
            this.Controls.Add(this.StartSimulation_button);
            this.Controls.Add(this.Mode3_RB);
            this.Controls.Add(this.Mode2_RB);
            this.Controls.Add(this.Mode1_RB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExportParameters_button);
            this.Controls.Add(this.ImportParameters_button);
            this.Controls.Add(this.ElCapacityField);
            this.Controls.Add(this.ElNumberField);
            this.Controls.Add(this.HeightField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimulationParametersView";
            this.Text = "Simulation Parameters";
            this.toolTip1.SetToolTip(this, "To activate \"Start Simulation\" button, all the fields must be set");
            this.Load += new System.EventHandler(this.SimulationParametersView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HeightField;
        private System.Windows.Forms.TextBox ElNumberField;
        private System.Windows.Forms.TextBox ElCapacityField;
        private System.Windows.Forms.Button ImportParameters_button;
        private System.Windows.Forms.Button ExportParameters_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Mode1_RB;
        private System.Windows.Forms.RadioButton Mode2_RB;
        private System.Windows.Forms.RadioButton Mode3_RB;
        private System.Windows.Forms.Button StartSimulation_button;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}