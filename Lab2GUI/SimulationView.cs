using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace Lab2GUI
{
    public partial class SimulationView : Form, ISimulationView
    {
        Color paint;
        int k = 0;
        int a = 0;

        public event Action GoToCreatePeopleForm;
        public event Action GetPeopleStatus;
        public event Action GoToSetRuleForm;
        public event Action GoToDeleteRuleForm;
        public event Action GoToChangeSpeedForm;
        public event Action FireAlarmActivate;
        public event Action FireAlarmDeactivate;
        public event Action PauseActivate;
        public event Action Stop;
        public event Action Print;

        public SimulationView()
        {
            InitializeComponent();

            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }

        public void FillTheGrid(string name, int id, int gstage, int astage, double time, bool in_elevator, bool reached, bool new_it)
        {
            if (new_it == true)
            {
                dataGridView1.Rows.Clear();
                if (in_elevator == false)
                {
                    if (reached == true)
                    {
                        dataGridView1.Rows.Add("Human_name" + " " + id, "Has reached " + astage + " stage");
                    }
                    else
                    {
                        dataGridView1.Rows.Add("Human_name" + " " + id, "Waiting for " + (int)(time / 1000) + " seconds at the " + gstage + " stage");
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("Human_name" + " " + id, "Moving to the " + astage + " in elevator");
                }
            }
            else
            {
                if (in_elevator == false)
                {
                    if (reached == true)
                    {
                        dataGridView1.Rows.Add("Human_name" + " " + id, "Has reached " + astage + " stage");
                    }
                    else
                    {
                        dataGridView1.Rows.Add("Human_name" + " " + id, "Waiting for " + (int)(time / 1000) + " seconds at the " + gstage + " stage");
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("Human_name" + " " + id, "Moving to the " + astage + " in elevator");
                }
            }
        }

        public void FillTheStatusBar(int minutes, int seconds, int people)
        {
            if (minutes > 0)
            {
                if (seconds < 10)
                {
                    TimeBar.Text = minutes + " : " + "0" + seconds;
                }
                else
                {
                    TimeBar.Text = minutes + " : " + seconds;
                }
            }
            else
            {
                TimeBar.Text = seconds.ToString();
            }
            TPeopleBar.Text = people.ToString();
        }

        public void FillTheElevatorsTable(int id, int people_inside, int actual_stage)
        {
            dataGridView2.Rows.Add("Elevator" + id, actual_stage, people_inside);
        }

        public void ClearTheRows()
        {
            dataGridView2.Rows.Clear();
        }

        public void FA_Activator()
        {
            paint = this.BackColor;
            this.BackColor = Color.Red;
            FA_On_button.Enabled = false;
            FA_Off_button.Enabled = true;
            CreatePeople_button.Enabled = false;
            SetRule_button.Enabled = false;
            a++;
        }

        public void FA_Deactivator()
        {
            this.BackColor = paint;
            FA_On_button.Enabled = true;
            FA_Off_button.Enabled = false;
            CreatePeople_button.Enabled = true;
            SetRule_button.Enabled = true;
            a = 0;
        }

        public void ClearTheGrid()
        {
            dataGridView1.Rows.Clear();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SimulationView_Load(object sender, EventArgs e)
        {
            //FA_Off_button.Enabled = false;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SetRule_button_Click(object sender, EventArgs e)
        {
            GoToSetRuleForm?.Invoke();
            /*SetRuleView f3 = new SetRuleView();
            f3.Show();
            Pause_button.Enabled = false;
            Stop_button.Enabled = false;
            ChangeSpeed_button.Enabled = false;
            GetPeopleStatus_button.Enabled = false;
            CreatePeople_button.Enabled = false;
            SetRule_button.Enabled = false;
            DeleteRule_button.Enabled = false;
            if (a == 1)
            {
                FA_Off_button.Enabled = false;
            }
            else
            {
                FA_On_button.Enabled = false;
            }
            f3.FormClosed += (object s, FormClosedEventArgs ev) =>
            {
                if (f3.rule_name != null)
                {
                    this.rule_names.Add(f3.rule_name);
                }
                if (k == 0)
                {
                    Pause_button.Enabled = true;
                    Stop_button.Enabled = true;
                    ChangeSpeed_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    DeleteRule_button.Enabled = true;
                    if (a == 1)
                    {
                        FA_Off_button.Enabled = true;
                    }
                    else
                    {
                        FA_On_button.Enabled = true;
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                }
                else
                {
                    Pause_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    if (a == 0)
                    {
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                    DeleteRule_button.Enabled = true;
                }
            };*/
        }

        private void ChangeSpeed_button_Click(object sender, EventArgs e)
        {
            GoToChangeSpeedForm?.Invoke();
            /*ChangeSpeedView f6 = new ChangeSpeedView();
            f6.Show();
            Pause_button.Enabled = false;
            Stop_button.Enabled = false;
            ChangeSpeed_button.Enabled = false;
            GetPeopleStatus_button.Enabled = false;
            CreatePeople_button.Enabled = false;
            SetRule_button.Enabled = false;
            DeleteRule_button.Enabled = false;
            if (a == 1)
            {
                FA_Off_button.Enabled = false;
            }
            else
            {
                FA_On_button.Enabled = false;
            }
            f6.FormClosed += (object s, FormClosedEventArgs ev) =>
            {
                Pause_button.Enabled = true;
                Stop_button.Enabled = true;
                ChangeSpeed_button.Enabled = true;
                GetPeopleStatus_button.Enabled = true;
                DeleteRule_button.Enabled = true;
                if (a == 1)
                {
                    FA_Off_button.Enabled = true;
                }
                else
                {
                    FA_On_button.Enabled = true;
                    CreatePeople_button.Enabled = true;
                    SetRule_button.Enabled = true;
                }
            };*/
        }

        private void CreatePeople_button_Click(object sender, EventArgs e)
        {
            GoToCreatePeopleForm?.Invoke();
            /*CreatePeopleView f7 = new CreatePeopleView();
            f7.Show();
            Pause_button.Enabled = false;
            Stop_button.Enabled = false;
            ChangeSpeed_button.Enabled = false;
            GetPeopleStatus_button.Enabled = false;
            CreatePeople_button.Enabled = false;
            SetRule_button.Enabled = false;
            DeleteRule_button.Enabled = false;
            if (a == 1)
            {
                FA_Off_button.Enabled = false;
            }
            else
            {
                FA_On_button.Enabled = false;
            }
            f7.FormClosed += (object s, FormClosedEventArgs ev) =>
            {
                if (k == 0)
                {
                    Pause_button.Enabled = true;
                    Stop_button.Enabled = true;
                    ChangeSpeed_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    CreatePeople_button.Enabled = true;
                    SetRule_button.Enabled = true;
                    DeleteRule_button.Enabled = true;
                    if (a == 1)
                    {
                        FA_Off_button.Enabled = true;
                    }
                    else
                    {
                        FA_On_button.Enabled = true;
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                }
                else
                {
                    Pause_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    if (a == 0)
                    {
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                    DeleteRule_button.Enabled = true;
                }
            };*/
        }

        private void GetPeopleStatus_button_Click(object sender, EventArgs e)
        {
            GetPeopleStatus?.Invoke();
            /*dataGridView1.Rows.Clear();
            Random rnd = new Random();
            int time1 = rnd.Next(0, 60);
            int time2 = rnd.Next(0, 60);
            dataGridView1.Rows.Add("Ivan Shimanski", "Waiting for " + time1 + " seconds");
            dataGridView1.Rows.Add("Danila Zhogol", "Waiting for " + time2 + " seconds");*/
        }

        private void FA_On_Click(object sender, EventArgs e)
        {
            FireAlarmActivate?.Invoke();
        }

        private void FA_Off_Click(object sender, EventArgs e)
        {
            FireAlarmDeactivate?.Invoke();
        }

        private void Pause_button_Click(object sender, EventArgs e)
        {
            PauseActivate?.Invoke();
            /*if (k == 0)
            {
                Stop_button.Enabled = false;
                ChangeSpeed_button.Enabled = false;
                if (a == 1)
                {
                    FA_Off_button.Enabled = false;
                }
                else
                {
                    FA_On_button.Enabled = false;
                }
                k++;
            }
            else
            {
                Stop_button.Enabled = true;
                ChangeSpeed_button.Enabled = true;
                if (a == 1)
                {
                    FA_Off_button.Enabled = true;
                }
                else
                {
                    FA_On_button.Enabled = true;
                    CreatePeople_button.Enabled = true;
                    SetRule_button.Enabled = true;
                }
                k = 0;
            }*/
        }

        private void DeleteRule_button_Click(object sender, EventArgs e)
        {
            GoToDeleteRuleForm?.Invoke();
            /*DeleteRuleView f8 = new DeleteRuleView(rule_names);
            f8.Show();
            Pause_button.Enabled = false;
            Stop_button.Enabled = false;
            ChangeSpeed_button.Enabled = false;
            GetPeopleStatus_button.Enabled = false;
            CreatePeople_button.Enabled = false;
            SetRule_button.Enabled = false;
            DeleteRule_button.Enabled = false;
            FA_On_button.Enabled = false;
            if (a == 1)
            {
                FA_Off_button.Enabled = false;
            }
            f8.FormClosed += (object s, FormClosedEventArgs ev) =>
            {
                this.rule_names = f8.rule_names;
                if (k == 0)
                {
                    Pause_button.Enabled = true;
                    Stop_button.Enabled = true;
                    ChangeSpeed_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    DeleteRule_button.Enabled = true;
                    if (a == 0)
                    {
                        FA_On_button.Enabled = true;
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                    else
                    {
                        FA_Off_button.Enabled = true;
                    }
                }
                else
                {
                    Pause_button.Enabled = true;
                    GetPeopleStatus_button.Enabled = true;
                    if (a == 0)
                    {
                        CreatePeople_button.Enabled = true;
                        SetRule_button.Enabled = true;
                    }
                    DeleteRule_button.Enabled = true;
                }
            };*/

        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            Stop?.Invoke();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Print?.Invoke();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
