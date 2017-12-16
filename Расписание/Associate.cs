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
                DBHelper.deleteWorker(id);
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
            DataTable dt = DBHelper.getWorkerData();   
            WorkerListGrid.Columns.Add("id", "ID");
            WorkerListGrid.Columns.Add("FIO", "ФИО");
            WorkerListGrid.Columns.Add("phone", "Телефон");
            WorkerListGrid.Columns.Add("division", "Подразделение");
            WorkerListGrid.Columns.Add("post", "Должность");
            WorkerListGrid.Columns.Add("hours", "Рабочие часы");
            WorkerListGrid.Columns.Add("timeTable", "График работы");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkerListGrid.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], DBHelper.findDivisionName(Convert.ToInt32(dt.Rows[i][3])), DBHelper.findPostName(Convert.ToInt32(dt.Rows[i][4])), DBHelper.findHoursName(Convert.ToInt32(dt.Rows[i][5])), DBHelper.findTimeTableName(Convert.ToInt32(dt.Rows[i][6])));               
            }
            WorkerListGrid.Columns[1].Width = 250;
        }

        private void button3_Click(object sender, EventArgs e) //редактировать
        {
            int index = WorkerListGrid.SelectedCells[0].RowIndex;
            AddAssociate editAssociate = new AddAssociate(WorkerListGrid.Rows[index].Cells[1].Value.ToString(), WorkerListGrid.Rows[index].Cells[2].Value.ToString(), Convert.ToInt32(WorkerListGrid.Rows[index].Cells[3].Value), WorkerListGrid.Rows[index].Cells[4].Value.ToString(), Convert.ToInt32(WorkerListGrid.Rows[index].Cells[5].Value), WorkerListGrid.Rows[index].Cells[6].Value.ToString(), "Редактировать сотрудника", "Сохранить изменения", Convert.ToInt32(WorkerListGrid.Rows[index].Cells[0].Value));
            editAssociate.ShowDialog();
            updateGrid();
        }
    }
}
