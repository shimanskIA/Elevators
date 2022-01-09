using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace Lab2GUI
{
    public partial class CreatePeopleView : Form, ICreatePeopleView
    {
        public CreatePeopleView()
        {
            InitializeComponent();
        }

        public event Action<string, string, string, string> GeneratePeople;

        private void Generate_button_Click(object sender, EventArgs e)
        {
            GeneratePeople?.Invoke(AmountField.Text, GStageField.Text, AimStageField.Text, AverageWeightField.Text);
        }

        private void CreatePeopleView_Load(object sender, EventArgs e)
        {
            //Generate_button.Enabled = false;
        }

        private void AmountField_TextChanged(object sender, EventArgs e)
        {
            /*if (GStageField.Text != null &&
                AmountField.Text != null &&
                AimStageField.Text != null &&
                GStageField.Text != "" &&
                AmountField.Text != "" &&
                AimStageField.Text != "")
            {
                Generate_button.Enabled = true;
            }
            else
            {
                Generate_button.Enabled = false;
            }*/
        }

        private void GStageField_TextChanged(object sender, EventArgs e)
        {
            /*if (GStageField.Text != null &&
                AmountField.Text != null &&
                AimStageField.Text != null &&
                GStageField.Text != "" &&
                AmountField.Text != "" &&
                AimStageField.Text != "")
            {
                Generate_button.Enabled = true;
            }
            else
            {
                Generate_button.Enabled = false;
            }*/
        }

        private void AimStageField_TextChanged(object sender, EventArgs e)
        {
            /*if (GStageField.Text != null &&
                AmountField.Text != null &&
                AimStageField.Text != null &&
                GStageField.Text != "" &&
                AmountField.Text != "" &&
                AimStageField.Text != "")
            {
                Generate_button.Enabled = true;
            }
            else
            {
                Generate_button.Enabled = false;
            }*/
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
