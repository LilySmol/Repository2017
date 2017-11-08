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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void associate_Click(object sender, EventArgs e) //сотрудники
        {
            Associate associate = new Associate();
            associate.ShowDialog();
        }

        void about_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            reference.Show();
        }

    }
}
