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

        public AddAssociate() //добавление 
        {
            InitializeComponent();
            divisionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            hoursComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            postComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public AddAssociate(string fio, string phone, int divisionName, string postName, int hoursName, string formName, string textButton, int id)
        {
            InitializeComponent();
            string[] fioSplit = fio.Split(' ');
            this.Text = formName;
            f.Text = fioSplit[0];
            i.Text = fioSplit[1];
            o.Text = fioSplit[2];            
            phoneBox.Text = phone;
            divisionComboBox.Text = divisionName.ToString();
            postComboBox2.Text = postName;
            hoursComboBox3.Text = hoursName.ToString();
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
        }

        private void button1_Click(object sender, EventArgs e) //cохранить
        {
            if (button1.Text == "Сохранить")
            {
                if (empty())
                {
                    if (numberValid())
                    {
                        if (validation())
                        {
                            string fio = f.Text + " " + i.Text + " " + o.Text;
                            DBHelper.addWorker(fio, phoneBox.Text, DBHelper.findDivisionId(Convert.ToInt32(divisionComboBox.Text)), DBHelper.findPostId(postComboBox2.Text), DBHelper.findHoursId(Convert.ToInt32(hoursComboBox3.Text)));
                            MessageBox.Show("Сотрудник сохранён;)");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные значения в поле Должность/Часы/Подразделение");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле телефона");
                        phoneBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля");
                }
            }
            else
            {
                if (empty())
                {
                    if (numberValid())
                    {
                        if (validation())
                        {
                            string fio = f.Text + " " + i.Text + " " + o.Text;
                            DBHelper.editWorker(fio, phoneBox.Text, DBHelper.findDivisionId(Convert.ToInt32(divisionComboBox.Text)), DBHelper.findPostId(postComboBox2.Text), DBHelper.findHoursId(Convert.ToInt32(hoursComboBox3.Text)), idWorker);
                            MessageBox.Show("Сотрудник отредактирован;)");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные значения в поле Должность/Часы/Подразделение");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле телефон");
                        phoneBox.Text = "";
                    }
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

        public bool empty()
        {
            if (f.Text != "" & i.Text != "" & o.Text != "" & divisionComboBox.Text != "" & hoursComboBox3.Text != "" & postComboBox2.Text != "")
            {
                return true;
            }
            return false;
        }

        public bool numberValid()
        {
            if (phoneBox.Text == "")
            {
                return true;
            }
            int res;
            bool isInt = Int32.TryParse(phoneBox.Text, out res);
            return isInt;
        }

        public bool validation()
        {
            try
            {
                if (DBHelper.findPostId(postComboBox2.Text) == -1 | DBHelper.findDivisionId(Convert.ToInt32(divisionComboBox.Text)) == -1 | DBHelper.findHoursId(Convert.ToInt32(hoursComboBox3.Text)) == -1)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
