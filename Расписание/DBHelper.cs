using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Расписание
{
    class DBHelper
    {
        static string dbname = File.ReadAllText(@"pathDB.txt");
        string connection = @"Data Source = " + dbname + ";Version = 3";

        public DataTable getWorkerData() //возвращает таблицу работников
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM worker", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable workerTable = new DataTable();
            workerTable.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            return workerTable;
        }

        public void addWorker(string fio, string phone, int division, int post, int hours, int timeTable)
        {
            int maxId = this.findMaxWorkerID(this.getWorkerData()) + 1;
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("INSERT INTO worker (workerID, FIO, phone, divisionID, postID, hoursID, timeTableID) VALUES ('"+maxId+"', '"+fio+"', '"+phone+"', '"+division+"', '"+post+"', '"+hours+"', '"+timeTable+"')", sqliteCon);
            sqliteCon.Open();
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public void deleteWorker(int id)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("DELETE FROM worker WHERE workerID = '" + id + "'", sqliteCon);
            sqliteCon.Open();
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public int findMaxWorkerID(DataTable workersTable)
        {
            int max = 0;
            for (int i = 0; i < workersTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(workersTable.Rows[i][0]) > max)
                {
                    max = Convert.ToInt32(workersTable.Rows[i][0]);
                }
            }
            return max;
        }

        public List<Division> getListDivision() //список подразделений
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM division", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<Division> listDivision = new List<Division>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listDivision.Add(new Division(Convert.ToInt32(table.Rows[i][0]), Convert.ToInt32(table.Rows[i][1])));
            }
            return listDivision;
        }

        public List<Post> getListPost() //список должностей
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM post", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<Post> listPost = new List<Post>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listPost.Add(new Post(Convert.ToInt32(table.Rows[i][0]), table.Rows[i][1].ToString()));
            }
            return listPost;
        }

        public List<Hours> getListHours() //список часов
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM hours", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<Hours> listHours = new List<Hours>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listHours.Add(new Hours(Convert.ToInt32(table.Rows[i][0]), Convert.ToInt32(table.Rows[i][1])));
            }
            return listHours;
        }

        public List<TimeTableHelp> getListTimeTable() //список грфика работы
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM timeTable", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<TimeTableHelp> listTimeTable = new List<TimeTableHelp>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listTimeTable.Add(new TimeTableHelp(Convert.ToInt32(table.Rows[i][0]), table.Rows[i][1].ToString()));
            }
            return listTimeTable;
        }
    }
}
