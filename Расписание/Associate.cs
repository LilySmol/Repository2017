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
    public partial class Associate : Form
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

        public Associate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAssociate addAssociate = new AddAssociate();
            addAssociate.ShowDialog();
            updateGrid();
        }

        private void button2_Click(object sender, EventArgs e) //удалить сотрудника
        {
            int index = WorkerListGrid.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(WorkerListGrid.Rows[index].Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить сотрудника?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db.deleteWorker(id);
                updateGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void Associate_Load(object sender, EventArgs e)
        {
            updateGrid();
        }

        void updateGrid()
        {
            WorkerListGrid.Rows.Clear();
            DataTable dt = db.getWorkerData();         
            listDivision = db.getListDivision();
            listPost = db.getListPost();
            listTimeTable = db.getListTimeTable();
            listHours = db.getListHours();
            WorkerListGrid.Columns.Add("id", "ID");
            WorkerListGrid.Columns.Add("FIO", "ФИО");
            WorkerListGrid.Columns.Add("phone", "Телефон");
            WorkerListGrid.Columns.Add("division", "Подразделение");
            WorkerListGrid.Columns.Add("post", "Должность");
            WorkerListGrid.Columns.Add("hours", "Рабочие часы");
            WorkerListGrid.Columns.Add("timeTable", "График работы");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkerListGrid.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], division.findDivisionName(Convert.ToInt32(dt.Rows[i][3]), listDivision), post.findPostName(Convert.ToInt32(dt.Rows[i][4]), listPost), hours.findHoursName(Convert.ToInt32(dt.Rows[i][5]), listHours), timeTable.findTimeTableName(Convert.ToInt32(dt.Rows[i][6]), listTimeTable));               
            }
            WorkerListGrid.Columns[1].Width = 250;
        }
    }
}
