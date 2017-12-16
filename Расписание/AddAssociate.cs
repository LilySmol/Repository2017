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
    public partial class AddAssociate : Form
    {
        int idWorker;

        public AddAssociate()
        {
            InitializeComponent();
            //loadData();
        }

        public AddAssociate(string fio, string phone, int divisionName, string postName, int hoursName, string timeTableName, string formName, string textButton, int id)
        {
            InitializeComponent();
            //loadData();
            string[] fioSplit = fio.Split(' ');
            this.Text = formName;
            f.Text = fioSplit[0];
            i.Text = fioSplit[1];
            o.Text = fioSplit[2];
            phoneBox.Text = phone;
            divisionComboBox.Text = divisionName.ToString();
            postComboBox2.Text = postName;
            hoursComboBox3.Text = hoursName.ToString();
            timeTableComboBox4.Text = timeTableName;
            button1.Text = textButton;
            idWorker = id;
        }

        private void loadData()
        {
            foreach (Division division in DBHelper.listDivision)
            {
                divisionComboBox.Items.Add(division.divisionName);
            }
            foreach (Post post in DBHelper.listPost)
            {
                postComboBox2.Items.Add(post.postName);
            }
            foreach (Hours hours in DBHelper.listHours)
            {
                hoursComboBox3.Items.Add(hours.hoursName);
            }
            foreach (TimeTableHelp timeTable in DBHelper.listTimeTable)
            {
                timeTableComboBox4.Items.Add(timeTable.timeTableName);
            }
        }

        private void button1_Click(object sender, EventArgs e) //cохранить
        {
            if (button1.Text == "Сохранить")
            {
                if (validation())
                {
                    string fio = f.Text + " " + i.Text + " " + o.Text;
                    DBHelper.addWorker(fio, phoneBox.Text, DBHelper.findDivisionId(Convert.ToInt32(divisionComboBox.Text)), DBHelper.findPostId(postComboBox2.Text), DBHelper.findHoursId(Convert.ToInt32(hoursComboBox3.Text)), DBHelper.findTimeTableId(timeTableComboBox4.Text));
                    MessageBox.Show("Сотрудник сохранён;)");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля");
                }
            }
            else
            {
                if (validation())
                {
                    string fio = f.Text + " " + i.Text + " " + o.Text;
                    DBHelper.editWorker(fio, phoneBox.Text, DBHelper.findDivisionId(Convert.ToInt32(divisionComboBox.Text)), DBHelper.findPostId(postComboBox2.Text), DBHelper.findHoursId(Convert.ToInt32(hoursComboBox3.Text)), DBHelper.findTimeTableId(timeTableComboBox4.Text), idWorker);
                    MessageBox.Show("Сотрудник отредактирован;)");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля");
                }
            }
        }

        private void AddAssociate_Load(object sender, EventArgs e)
        {
            loadData();
            
        }

        public bool validation()
        {
            if (f.Text != "" & i.Text != "" & o.Text != "" & divisionComboBox.Text != "" & hoursComboBox3.Text != "" & postComboBox2.Text != "" & timeTableComboBox4.Text != "")
            {
                return true;
            }
            return false;
        }
    }
}
