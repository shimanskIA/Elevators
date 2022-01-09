using System;
using System.Collections;
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
    public partial class DeleteRuleView : Form, IDeleteRuleView
    {
        //public ArrayList rule_names = new ArrayList();

        public event Action<string> DeleteRule;
        public void FillTheBox(List<string> rule_names)
        {
            for (int i = 0; i < rule_names.Count(); i++)
            {
                listBox1.Items.Add(rule_names[i]);
            }
        }

        public void ClearTheRow()
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        public DeleteRuleView()
        {
            InitializeComponent();
        }

        public DeleteRuleView(ArrayList a)
        {
            //this.rule_names = a;
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (listBox1.SelectedIndex >= 0)
            {
                Delete_button.Enabled = true;
            }*/
        }

        private void DeleteRuleView_Load(object sender, EventArgs e)
        {
            //Delete_button.Enabled = false;
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            DeleteRule?.Invoke((string)listBox1.SelectedItem);
            /*int ind = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            this.rule_names.RemoveAt(ind);
            Delete_button.Enabled = false;*/
        }
    }
}
