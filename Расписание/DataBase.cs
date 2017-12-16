using System;
using System.IO;
using System.Windows.Forms;

namespace Расписание
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(@"pathDB.txt");
        }

        private void button1_Click(object sender, EventArgs e) //выбрать файл
        {
            string name="";

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            name = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            textBox1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e) //подключить бд
        {
            File.WriteAllText(@"pathDB.txt", textBox1.Text);
            MessageBox.Show("База данных подключена");
            this.Close();
        }
    }
}
