using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расписание
{
    public partial class Timetable : Form
    {
        List<TimingTable> listTiming = new List<TimingTable>();      

        public Timetable()
        {
            InitializeComponent();

            ToolStripMenuItem associate = new ToolStripMenuItem("Сотрудники");
            associate.Click += associate_Click;

            menuStrip.Items.Add(associate);

            ToolStripMenuItem about = new ToolStripMenuItem("О программе");
            about.Click += about_Click;
            menuStrip.Items.Add(about);

            ToolStripMenuItem database = new ToolStripMenuItem("База данных");
            database.Click += database_Click;
            menuStrip.Items.Add(database);

            foreach (TimeTableHelp time in DBHelper.listTimeTable)
            {
                comboBoxTimeTable.Items.Add(time.timeTableName);
            }
            foreach (string timeWork in DBHelper.listTimeWork)
            {
                comboBoxTimeWork.Items.Add(timeWork);
            }

            if (DBHelper.getSettings() != null)
            {
                dateTimeStart.Text = DBHelper.settings.dayStart.ToString();
                comboBoxTimeTable.Text = DBHelper.settings.timeTable;
                comboBoxTimeWork.Text = DBHelper.settings.timeWork;
                if (DBHelper.settings.countDays == 7)
                {
                    week.Checked = true;
                }
                else
                {
                    month.Checked = true;
                }
                showDataTable();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void associate_Click(object sender, EventArgs e) //сотрудники
        {
            Associate associate = new Associate();
            associate.ShowDialog();
        }

        void about_Click(object sender, EventArgs e) //о программе
        {
            Reference reference = new Reference();
            reference.Show();
        }

        void database_Click(object sender, EventArgs e)
        {
            DataBase db_form = new DataBase();
            db_form.ShowDialog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //составить расписание
        {
            if (valibation())
            {
                DateTime dayStart = dateTimeStart.Value;
                int timeStart = Convert.ToInt32(comboBoxTimeWork.Text.Split('-')[0]);
                int days = (week.Checked) ? 7 : 30;
                WorkWithSchedule w = new WorkWithSchedule();
                w.makeSchedule(days, timeStart, dayStart, comboBoxTimeTable.Text);
                listTiming = w.listTiming;           
                updateDataTable();
            }
        }

        private void showDataTable()
        {
            DateTime dayStart = dateTimeStart.Value;
            int timeStart = Convert.ToInt32(comboBoxTimeWork.Text.Split('-')[0]);
            int days = (week.Checked) ? 7 : 30;
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);

            dataGridTimeTable.Columns.Add("fio", "ФИО");
            for (int i = 0; i < days; i++)
            {
                dataGridTimeTable.Columns.Add(dayStart.Date.ToString("d"), dayStart.Date.ToString("d"));
                dayStart += oneDay;
            }
            foreach (Worker worker in DBHelper.listWorker)
            {
                dataGridTimeTable.Rows.Add(worker.FIO);
            }
            foreach (TimingTable data in DBHelper.listTimingTable)
            {
                for (int j = 0; j < DBHelper.listWorker.Count; j++)
                {
                    string workerName = DBHelper.findWorkerName(data.workerID);
                    string val = dataGridTimeTable[0, j].Value.ToString();
                    if (workerName == val)
                    {
                        dataGridTimeTable[data.data.Date.ToString("d"), j].Value = data.hours;
                    }
                }
            }
        }

        private void updateDataTable()
        {
            dataGridTimeTable.Rows.Clear();
            DateTime dayStart = dateTimeStart.Value;
            int timeStart = Convert.ToInt32(comboBoxTimeWork.Text.Split('-')[0]);
            int days = (week.Checked) ? 7 : 30;
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);

            dataGridTimeTable.Columns.Add("fio", "ФИО");
            for (int i = 0; i < days; i++)
            {
                dataGridTimeTable.Columns.Add(dayStart.Date.ToString("d"), dayStart.Date.ToString("d"));
                dayStart += oneDay;
            }
            foreach (Worker worker in DBHelper.listWorker)
            {
                dataGridTimeTable.Rows.Add(worker.FIO);
            }
            foreach (TimingTable data in listTiming)
            {
                for (int j = 0; j < DBHelper.listWorker.Count; j++)
                {
                    string workerName = DBHelper.findWorkerName(data.workerID);
                    string val = dataGridTimeTable[0, j].Value.ToString();
                    if (workerName == val)
                    {
                        dataGridTimeTable[data.data.Date.ToString("d"), j].Value = data.hours;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //сохранить расписание и настройки
        {
            DateTime dayStart = dateTimeStart.Value;
            string timeStart = comboBoxTimeWork.Text;
            int days = (week.Checked) ? 7 : 30;
            DBHelper.saveTimeWork(listTiming);
            DBHelper.saveSettings(days, dayStart, timeStart, comboBoxTimeTable.Text);
            MessageBox.Show("сохранено");
        }

        private bool valibation()
        {
            if (dateTimeStart.Text == "" | comboBoxTimeTable.Text == "" | comboBoxTimeWork.Text == "")
            {
                MessageBox.Show("Заполните все необходимые поля");
                return false;
            }
            return true;
        }
    }
}
