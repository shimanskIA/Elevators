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
    public partial class StatsView : Form, IStatsView
    {
        public StatsView()
        {
            InitializeComponent();
        }

        public void FillTheElevatorsGrid(int id, int transported_people, int rides, int empty_rides)
        {
            dataGridView2.Rows.Add("Elevator" + " " + id, transported_people, rides, empty_rides);
        }

        public void FillTheInfosGrid(int rides, int avg_waiting_time, int max_waiting_time, int total_waiting_time, int fa_amount, int fa_sum_length)
        {
            dataGridView1.Rows.Add("Total amount of rides  -  " + rides);
            dataGridView1.Rows.Add("Average waiting time  -  " + avg_waiting_time + "  seconds");
            dataGridView1.Rows.Add("Maximal waiting time  -  " + max_waiting_time + "  seconds");
            dataGridView1.Rows.Add("Total waiting time  -  " + total_waiting_time + "  seconds");
            dataGridView1.Rows.Add("Total amount of fire alarms  -  " + fa_amount);
            dataGridView1.Rows.Add("Total time of time alarms  -  " + fa_sum_length + "  seconds");
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {

        }
    }
}
