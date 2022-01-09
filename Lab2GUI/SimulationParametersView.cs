using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation;

namespace Lab2GUI
{
    public partial class SimulationParametersView : Form, ISimulationParametersView
    {
        public SimulationParametersView()
        {
            InitializeComponent();
        }

        public event Action<string, string, string, string> ExportParameters;
        public event Action<string> ImportParameters;
        public event Action<string, string, string, bool, bool, bool> LoadParameters;
        public event Action ManageHeightFieldActivity;
        public event Action ManageElNumberFieldActivity;
        public event Action ManageElCapacityFieldActivity;

        public void FillTheFields(string p1, string p2, string p3)
        {
            HeightField.Clear();
            ElNumberField.Clear();
            ElCapacityField.Clear();
            HeightField.Text = p1;
            ElNumberField.Text = p2;
            ElCapacityField.Text = p3;
        }

        public void FieldsNButtonsActivityController1()
        {
            StartSimulation_button.Enabled = false;
            ExportParameters_button.Enabled = false;
        }

        public void HeightField_ActivityManager()
        {
            if (HeightField.Text != null &&
                ElNumberField.Text != null &&
                ElCapacityField.Text != null &&
                HeightField.Text != "" &&
                ElNumberField.Text != "" &&
                ElCapacityField.Text != "" &&
                int.TryParse(HeightField.Text, out int a) == true &&
                int.TryParse(ElNumberField.Text, out int b) == true &&
                int.TryParse(ElCapacityField.Text, out int c) == true)
            {
                if (int.Parse(HeightField.Text) <= 20 && int.Parse(ElNumberField.Text) <= 5)
                {
                    StartSimulation_button.Enabled = true;
                    ExportParameters_button.Enabled = true;
                }
                else
                {
                    StartSimulation_button.Enabled = false;
                    ExportParameters_button.Enabled = false;
                }
            }
            else
            {
                StartSimulation_button.Enabled = false;
                ExportParameters_button.Enabled = false;
            }
        }

        public void ElNumberField_ActivityManager()
        {
            if (HeightField.Text != null &&
                ElNumberField.Text != null &&
                ElCapacityField.Text != null &&
                HeightField.Text != "" &&
                ElNumberField.Text != "" &&
                ElCapacityField.Text != "" &&
                int.TryParse(HeightField.Text, out int a) == true &&
                int.TryParse(ElNumberField.Text, out int b) == true &&
                int.TryParse(ElCapacityField.Text, out int c) == true)
            {
                if (int.Parse(HeightField.Text) <= 20 && int.Parse(ElNumberField.Text) <= 5)
                {
                    StartSimulation_button.Enabled = true;
                    ExportParameters_button.Enabled = true;
                }
                else
                {
                    StartSimulation_button.Enabled = false;
                    ExportParameters_button.Enabled = false;
                }
            }
            else
            {
                StartSimulation_button.Enabled = false;
                ExportParameters_button.Enabled = false;
            }
        }

        public void ElCapacityField_ActivityManager()
        {
            if (HeightField.Text != null &&
                ElNumberField.Text != null &&
                ElCapacityField.Text != null &&
                HeightField.Text != "" &&
                ElNumberField.Text != "" &&
                ElCapacityField.Text != "" &&
                int.TryParse(HeightField.Text, out int a) == true &&
                int.TryParse(ElNumberField.Text, out int b) == true &&
                int.TryParse(ElCapacityField.Text, out int c) == true)
            {
                if (int.Parse(HeightField.Text) <= 20 && int.Parse(ElNumberField.Text) <= 5)
                {
                    StartSimulation_button.Enabled = true;
                    ExportParameters_button.Enabled = true;
                }
                else
                {
                    StartSimulation_button.Enabled = false;
                    ExportParameters_button.Enabled = false;
                }
            }
            else
            {
                StartSimulation_button.Enabled = false;
                ExportParameters_button.Enabled = false;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void StartSimulation_button_Click(object sender, EventArgs e)
        {
            LoadParameters?.Invoke(HeightField.Text, ElNumberField.Text, ElCapacityField.Text, Mode1_RB.Checked, Mode2_RB.Checked, Mode3_RB.Checked);
        }

        private void SimulationParametersView_Load(object sender, EventArgs e)
        {

        }

        private void ImportParameters_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportParameters?.Invoke(openFileDialog1.FileName);
            }
        }

        private void ExportParameters_button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportParameters?.Invoke(saveFileDialog1.FileName, HeightField.Text, ElNumberField.Text, ElCapacityField.Text);
            }
        }

        private void HeightField_TextChanged(object sender, EventArgs e)
        {
            ManageHeightFieldActivity?.Invoke();
        }

        private void ElNumberField_TextChanged(object sender, EventArgs e)
        {
            ManageElNumberFieldActivity?.Invoke();
        }

        private void ElCapacityField_TextChanged(object sender, EventArgs e)
        {
            ManageElCapacityFieldActivity?.Invoke();
        }

        private void Mode1_RB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
