using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace Lab2GUI
{
    public partial class SetRuleView : Form, ISetRuleView
    {
        //public string rule_name;
        //private string name;
        //private string name2;

        public event Action<string, string, string, string, string, string, string> AddFixedGenRule;
        public event Action<string, string, string, string, string, string> AddRandomGenRule;
        public event Action<string, string, string, string, string, string, string> ExportLeftRule;
        public event Action<string, string, string, string, string, string, string, string> ExportRightRule;
        public event Action<string> ImportRightRule;
        public event Action<string> ImportLeftRule;
        public event Action ManageFixedGenRBActivity;
        public event Action ManageRandomGenRBActivity;
        public event Action ManageRightFieldActivity;
        public event Action ManageLeftFieldActivity;
        public event Action ManageFieldsNButtonsActivity;

        public void FixedGen_RB_ActivityManager()
        {
            TimeFieldLeft.Enabled = false;
            AmountFieldLeft.Enabled = false;
            GStageFieldLeft.Enabled = false;
            AimStageFieldLeft.Enabled = false;
            RuleNameFieldLeft.Enabled = false;
            AverageWeightFieldLeft.Enabled = false;
            TimeFieldRight.Enabled = true;
            AmountFieldRight.Enabled = true;
            GStageFieldRight.Enabled = true;
            AimStageFieldRight.Enabled = true;
            IntervalField.Enabled = true;
            RuleNameFieldRight.Enabled = true;
            AverageWeightFieldRight.Enabled = true;
            if (TimeFieldRight.Text != null &&
            AmountFieldRight.Text != null &&
            GStageFieldRight.Text != null &&
            AimStageFieldRight.Text != null &&
            IntervalField.Text != null &&
            RuleNameFieldRight.Text != null &&
            AverageWeightFieldRight.Text != null &&
            TimeFieldRight.Text != "" &&
            AmountFieldRight.Text != "" &&
            GStageFieldRight.Text != "" &&
            AimStageFieldRight.Text != "" &&
            IntervalField.Text != "" &&
            AverageWeightFieldRight.Text != "" &&
            RuleNameFieldRight.Text != "")
            {
                AcceptNExit_button.Enabled = true;
                ExportRule_button.Enabled = true;
            }
            else
            {
                AcceptNExit_button.Enabled = false;
                ExportRule_button.Enabled = false;
            }
        }

        public void RandomGen_RB_ActivityManager()
        {
            TimeFieldRight.Enabled = false;
            AmountFieldRight.Enabled = false;
            GStageFieldRight.Enabled = false;
            AimStageFieldRight.Enabled = false;
            IntervalField.Enabled = false;
            RuleNameFieldRight.Enabled = false;
            AverageWeightFieldRight.Enabled = false;
            TimeFieldLeft.Enabled = true;
            AmountFieldLeft.Enabled = true;
            GStageFieldLeft.Enabled = true;
            AimStageFieldLeft.Enabled = true;
            AverageWeightFieldLeft.Enabled = true;
            RuleNameFieldLeft.Enabled = true;
            if (
           TimeFieldLeft.Text != null &&
           AmountFieldLeft.Text != null &&
           GStageFieldLeft.Text != null &&
           AimStageFieldLeft.Text != null &&
           RuleNameFieldLeft.Text != null &&
           AverageWeightFieldLeft.Text != null &&
           TimeFieldLeft.Text != "" &&
           AmountFieldLeft.Text != "" &&
           GStageFieldLeft.Text != "" &&
           AimStageFieldLeft.Text != "" &&
           AverageWeightFieldLeft.Text != "" &&
           RuleNameFieldLeft.Text != "")
            {
                AcceptNExit_button.Enabled = true;
                ExportRule_button.Enabled = true;
            }
            else
            {
                AcceptNExit_button.Enabled = false;
                ExportRule_button.Enabled = false;
            }
        }

        public void LeftField_ActivityManager()
        {
            if (RuleNameFieldLeft.Text != null &&
               AimStageFieldLeft.Text != null &&
               GStageFieldLeft.Text != null &&
               AmountFieldLeft.Text != null &&
               TimeFieldLeft.Text != null &&
               AverageWeightFieldLeft.Text != null &&
               RuleNameFieldLeft.Text != "" &&
               AimStageFieldLeft.Text != "" &&
               GStageFieldLeft.Text != "" &&
               AmountFieldLeft.Text != "" &&
               AverageWeightFieldLeft.Text != "" &&
               TimeFieldLeft.Text != "" &&
               RuleNameFieldRight.Enabled == false)
            {
                AcceptNExit_button.Enabled = true;
                ExportRule_button.Enabled = true;
            }
            else
            {
                AcceptNExit_button.Enabled = false;
                ExportRule_button.Enabled = false;
            }
        }

        public void RightField_ActivityManager()
        {
            if (RuleNameFieldRight.Text != null &&
                 IntervalField.Text != null &&
                 AimStageFieldRight.Text != null &&
                 GStageFieldRight.Text != null &&
                 AmountFieldRight.Text != null &&
                 TimeFieldRight.Text != null &&
                 AverageWeightFieldRight.Text != null &&
                 RuleNameFieldRight.Text != "" &&
                 IntervalField.Text != "" &&
                 AimStageFieldRight.Text != "" &&
                 GStageFieldRight.Text != "" &&
                 AmountFieldRight.Text != "" &&
                 AverageWeightFieldRight.Text != "" &&
                 TimeFieldRight.Text != "" &&
                 RuleNameFieldLeft.Enabled == false)
            {
                AcceptNExit_button.Enabled = true;
                ExportRule_button.Enabled = true;
            }
            else
            {
                AcceptNExit_button.Enabled = false;
                ExportRule_button.Enabled = false;
            }
        }

        public void FieldsNButtonsActivityManager1()
        {
            AcceptNExit_button.Enabled = false;
            ExportRule_button.Enabled = false;
        }

        public void FillTheFields(List <string> parameters)
        {
            if (TimeFieldLeft.Enabled == true)
            {
                TimeFieldLeft.Clear();
                AmountFieldLeft.Clear();
                GStageFieldLeft.Clear();
                AimStageFieldLeft.Clear();
                AverageWeightFieldLeft.Clear();
                RuleNameFieldLeft.Clear();
                TimeFieldLeft.Text = parameters.ElementAt(0);
                AmountFieldLeft.Text = parameters.ElementAt(1);
                GStageFieldLeft.Text = parameters.ElementAt(2);
                AimStageFieldLeft.Text = parameters.ElementAt(3);
                AverageWeightFieldLeft.Text = parameters.ElementAt(4);
                RuleNameFieldLeft.Text = parameters.ElementAt(5);
            }
            else
            {
                TimeFieldRight.Clear();
                AmountFieldRight.Clear();
                GStageFieldRight.Clear();
                AimStageFieldRight.Clear();
                IntervalField.Clear();
                AverageWeightFieldRight.Clear();
                RuleNameFieldRight.Clear();
                TimeFieldRight.Text = parameters.ElementAt(0);
                AmountFieldRight.Text = parameters.ElementAt(1);
                GStageFieldRight.Text = parameters.ElementAt(2);
                AimStageFieldRight.Text = parameters.ElementAt(3);
                IntervalField.Text = parameters.ElementAt(4);
                AverageWeightFieldRight.Text = parameters.ElementAt(5);
                RuleNameFieldRight.Text = parameters.ElementAt(6);
            }
        }

        public SetRuleView()
        {
            InitializeComponent();
        }
        private void FixedGen_RB_CheckedChanged(object sender, EventArgs e)
        {
            ManageFixedGenRBActivity?.Invoke();
        }

        private void RandomGen_RB_CheckedChanged(object sender, EventArgs e)
        {
            ManageRandomGenRBActivity?.Invoke();
        }

        private void AcceptNExit_button_Click(object sender, EventArgs e)
        {
            if (RuleNameFieldLeft.Enabled == false)
            {
                AddFixedGenRule?.Invoke(TimeFieldRight.Text, AmountFieldRight.Text, GStageFieldRight.Text, AimStageFieldRight.Text, IntervalField.Text, AverageWeightFieldRight.Text, RuleNameFieldRight.Text);
            }
            else
            {
                AddRandomGenRule?.Invoke(TimeFieldLeft.Text, AmountFieldLeft.Text, GStageFieldLeft.Text, AimStageFieldLeft.Text, AverageWeightFieldLeft.Text, RuleNameFieldLeft.Text);
            }
        }

        private void RuleNameFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void RuleNameFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }

        private void SetRuleView_Load(object sender, EventArgs e)
        {
            ManageFieldsNButtonsActivity?.Invoke();
        }

        private void TimeFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }

        private void TimeFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void AmountFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void GStageFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void AimStageFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void AmountFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }

        private void GStageFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }

        private void AimStageFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }

        private void IntervalField_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void ImportRule_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //name2 = openFileDialog1.FileName;
                if (TimeFieldLeft.Enabled == true)
                {
                    ImportLeftRule?.Invoke(openFileDialog1.FileName);
                    /*TimeFieldLeft.Clear();
                    AmountFieldLeft.Clear();
                    GStageFieldLeft.Clear();
                    AimStageFieldLeft.Clear();
                    RuleNameFieldLeft.Clear();
                    StreamReader rdr = new StreamReader(name2);
                    TimeFieldLeft.Text = rdr.ReadLine();
                    AmountFieldLeft.Text = rdr.ReadLine();
                    GStageFieldLeft.Text = rdr.ReadLine();
                    AimStageFieldLeft.Text = rdr.ReadLine();
                    RuleNameFieldLeft.Text = rdr.ReadLine();
                    rdr.Close();*/
                }
                else
                {
                    ImportRightRule?.Invoke(openFileDialog1.FileName);
                    /*TimeFieldRight.Clear();
                    AmountFieldRight.Clear();
                    GStageFieldRight.Clear();
                    AimStageFieldRight.Clear();
                    IntervalField.Clear();
                    RuleNameFieldRight.Clear();
                    StreamReader rdr = new StreamReader(name2);
                    TimeFieldRight.Text = rdr.ReadLine();
                    AmountFieldRight.Text = rdr.ReadLine();
                    GStageFieldRight.Text = rdr.ReadLine();
                    AimStageFieldRight.Text = rdr.ReadLine();
                    IntervalField.Text = rdr.ReadLine();
                    RuleNameFieldRight.Text = rdr.ReadLine();
                    rdr.Close();*/
                }
            }
        }

        private void ExportRule_button_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (TimeFieldLeft.Enabled == true)
                {
                    ExportLeftRule?.Invoke(saveFileDialog1.FileName, TimeFieldLeft.Text, AmountFieldLeft.Text, GStageFieldLeft.Text, AimStageFieldLeft.Text, AverageWeightFieldLeft.Text, RuleNameFieldLeft.Text);
                    /*StreamWriter wrt = new StreamWriter(name);
                    wrt.WriteLine(TimeFieldLeft.Text);
                    wrt.WriteLine(AmountFieldLeft.Text);
                    wrt.WriteLine(GStageFieldLeft.Text);
                    wrt.WriteLine(AimStageFieldLeft.Text);
                    wrt.WriteLine(RuleNameFieldLeft.Text);
                    wrt.Close();*/
                }
                else
                {
                    ExportRightRule?.Invoke(saveFileDialog1.FileName, TimeFieldRight.Text, AmountFieldRight.Text, GStageFieldRight.Text, AimStageFieldRight.Text, IntervalField.Text, AverageWeightFieldRight.Text, RuleNameFieldRight.Text);
                    /*StreamWriter wrt = new StreamWriter(name);
                    wrt.WriteLine(TimeFieldRight.Text);
                    wrt.WriteLine(AmountFieldRight.Text);
                    wrt.WriteLine(GStageFieldRight.Text);
                    wrt.WriteLine(AimStageFieldRight.Text);
                    wrt.WriteLine(IntervalField.Text);
                    wrt.WriteLine(RuleNameFieldRight.Text);
                    wrt.Close();*/
                }
            }
        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void AverageWeightFieldLeft_TextChanged(object sender, EventArgs e)
        {
            ManageLeftFieldActivity?.Invoke();
        }

        private void AverageWeightFieldRight_TextChanged(object sender, EventArgs e)
        {
            ManageRightFieldActivity?.Invoke();
        }
    }
}
