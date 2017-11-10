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
        DBHelper db = new DBHelper();
        Division division = new Division();
        Post post = new Post();
        Hours hours = new Hours();
        TimeTableHelp timeTable = new TimeTableHelp();
        List<Division> listDivision = new List<Division>();
        List<Post> listPost = new List<Post>();
        List<Hours> listHours = new List<Hours>();
        List<TimeTableHelp> listTimeTable = new List<TimeTableHelp>();

        public AddAssociate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //cохранить
        {
            if (validation())
            {
                string fio = f.Text + " " + i.Text + " " + o.Text;
                db.addWorker(fio, phoneBox.Text, division.findDivisionId(Convert.ToInt32(divisionComboBox.Text), listDivision), post.findPostId(postComboBox2.Text, listPost), hours.findHoursId(Convert.ToInt32(hoursComboBox3.Text), listHours), timeTable.findTimeTableId(timeTableComboBox4.Text, listTimeTable));
                MessageBox.Show("Сотрудник сохранён;)");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля");
            }
        }

        private void AddAssociate_Load(object sender, EventArgs e)
        {
            listDivision = db.getListDivision();
            listPost = db.getListPost();
            listTimeTable = db.getListTimeTable();
            listHours = db.getListHours();
            for (int i = 0; i < listDivision.Count; i++)
            {
                divisionComboBox.Items.Add(listDivision[i].divisionName);                
            }
            for (int i = 0; i < listPost.Count; i++)
            {
                postComboBox2.Items.Add(listPost[i].postName);
            }
            for (int i = 0; i < listHours.Count; i++)
            {
                hoursComboBox3.Items.Add(listHours[i].hoursName);
            }
            for (int i = 0; i < listTimeTable.Count; i++)
            {
                timeTableComboBox4.Items.Add(listTimeTable[i].timeTableName);
            }
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
