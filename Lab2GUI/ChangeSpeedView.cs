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
    public partial class ChangeSpeedView : Form, IChangeSpeedView
    {
        public event Action<double> ChangeSpeed;
        public ChangeSpeedView()
        {
            InitializeComponent();
        }

        private void x025_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(0.25);
            //this.Close();
        }

        private void x01_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(0.1);
            //this.Close();
        }

        private void x2_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(2.0);
            //this.Close();
        }

        private void x4_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(4.0);
            //this.Close();
        }

        private void x8_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(8.0);
            //this.Close();
        }

        private void x1_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(1.0);
            //this.Close();
        }

        private void x075_button_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void x05_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(0.5);
            //this.Close();
        }

        private void ChangeSpeedView_Load(object sender, EventArgs e)
        {

        }

        private void X075_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(0.75);
        }

        private void X16_button_Click(object sender, EventArgs e)
        {
            ChangeSpeed?.Invoke(16.0);
        }
    }
}
