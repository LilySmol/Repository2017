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
        public Timetable()
        {
            InitializeComponent();

            ToolStripMenuItem associate = new ToolStripMenuItem("Сотрудники");
            associate.Click += associate_Click;

            //fileItem.DropDownItems.Add("Сотрудник");
            //fileItem.DropDownItems.Add("Добавить сотрудника");
            //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

            menuStrip.Items.Add(associate);

            ToolStripMenuItem about = new ToolStripMenuItem("О программе");
            about.Click += about_Click;
            menuStrip.Items.Add(about);

            ToolStripMenuItem database = new ToolStripMenuItem("База данных");
            database.Click += database_Click;
            menuStrip.Items.Add(database);
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

        private void button2_Click(object sender, EventArgs e)
        {

            WorkWithSchedule.makeSchedule(7, 8, DateTime.Now, "2/2");
            List<TimingTable> listTiming = WorkWithSchedule.listTiming;
        }
    }
}
