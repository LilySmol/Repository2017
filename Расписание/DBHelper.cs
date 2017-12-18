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
        static string connection = @"Data Source = " + dbname + ";Version = 3";
        public static List<Hours> listHours = getListHours();
        public static List<Post> listPost = getListPost();
        public static List<Division> listDivision = getListDivision();
        public static List<TimeTableHelp> listTimeTable = getListTimeTable();
        public static List<Worker> listWorker = getWorkerList();
        public static List<string> listTimeWork = getListTimeWork();
        public static Settings settings = getSettings();
        public static List<TimingTable> listTimingTable = getListTimingTable();
        public static List<string> listCombobox = getList();

        public static List<string> getList()
        {
            List<string> list = new List<string>();
            list.Add("0");
            foreach (string time in listTimeWork)
            {
                foreach (Hours hours in listHours)
                {
                    list.Add(time.Split('-')[0] + "-" + (Convert.ToInt32(time.Split('-')[0]) + hours.hoursName));
                }
            }
            return list;
        }

        public static DataTable getWorkerData() //возвращает таблицу работников
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

        public static List<Worker> getWorkerList() //возвращает список работников
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM worker", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<Worker> listWorkers = new List<Worker>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listWorkers.Add(new Worker(Convert.ToInt32(table.Rows[i][0]), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), Convert.ToInt32(table.Rows[i][3]), Convert.ToInt32(table.Rows[i][4]), Convert.ToInt32(table.Rows[i][5]), Convert.ToInt32(table.Rows[i][6])));
            }
            return listWorkers;
        }

        public static void addWorker(string fio, string phone, int division, int post, int hours, int timeTable)
        {
            int maxId = findMaxWorkerID(getWorkerData()) + 1;
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("INSERT INTO worker (workerID, FIO, phone, divisionID, postID, hoursID, timeTableID) VALUES ('"+maxId+"', '"+fio+"', '"+phone+"', '"+division+"', '"+post+"', '"+hours+"', '"+timeTable+"')", sqliteCon);
            sqliteCon.Open();
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public static void editWorker(string fio, string phone, int division, int post, int hours, int timeTable, int id)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            string comand = "UPDATE worker SET FIO='" + fio + "', phone='" + phone + "', divisionID=" + division + ", postID=" + post + ", hoursID=" + hours+", timeTableID=" + timeTable + " WHERE workerID=" + id;
            //string comand = "UPDATE worker SET FIO='" + fio + "' WHERE workerID=" + id;
            SQLiteCommand sqliteCom = new SQLiteCommand(comand, sqliteCon);
            sqliteCon.Open();
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public static void deleteWorker(int id)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("DELETE FROM worker WHERE workerID = '" + id + "'", sqliteCon);
            sqliteCon.Open();
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public static int findMaxWorkerID(DataTable workersTable)
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

        public static List<Division> getListDivision() //список подразделений
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

        public static List<Post> getListPost() //список должностей
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

        public static List<Hours> getListHours() //список часов
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

        public static List<TimeTableHelp> getListTimeTable() //список грфика работы
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
        
        public static List<TimingTable> getListTimingTable() //список с расписанием
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM timing", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<TimingTable> listTiming = new List<TimingTable>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listTiming.Add(new TimingTable(Convert.ToInt32(table.Rows[i][0]), Convert.ToInt32(table.Rows[i][1]), Convert.ToDateTime(table.Rows[i][2]), table.Rows[i][3].ToString()));
            }
            return listTiming;
        }

        public static void saveTimeWork(List<TimingTable> list) //сохранить график работы персонала
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            sqliteCon.Open();
            SQLiteCommand sqliteCom = new SQLiteCommand("DELETE FROM timing", sqliteCon);
            sqliteCom.ExecuteNonQuery();
            foreach (TimingTable table in list)
            {
                sqliteCom = new SQLiteCommand("INSERT INTO timing (timingID, workerID, data, hours) VALUES (" + table.timingID + ", " + table.workerID + ", '" + table.data + "', '" + table.hours + "')", sqliteCon);
                sqliteCom.ExecuteNonQuery();
            }
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public static List<string> getListTimeWork() //список с режимом работы
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM timeWork", sqliteCon);
            sqliteCon.Open();
            SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqliteReader);
            sqliteCon.Close();
            sqliteCon.Dispose();
            List<string> listTimeWork = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listTimeWork.Add(table.Rows[i][1].ToString());
            }
            return listTimeWork;
        }

        public static int findHoursId(int hoursN) //найти id часов по наименованию
        {            
            for (int i = 0; i < listHours.Count; i++)
            {
                if (listHours[i].hoursName == hoursN)
                {
                    return listHours[i].hoursID;
                }
            }
            return -1;
        }

        public static int findHoursName(int hoursId) //найти наименование часов по id
        {
            for (int i = 0; i < listHours.Count; i++)
            {
                if (listHours[i].hoursID == hoursId)
                {
                    return listHours[i].hoursName;
                }
            }
            return -1;
        }

        public static int findPostId(string postN) //найти id должности по наименованию
        {
            
            for (int i = 0; i < listPost.Count; i++)
            {
                if (listPost[i].postName == postN)
                {
                    return listPost[i].postID;
                }
            }
            return -1;
        }

        public static string findPostName(int postId) //найти наименование должности по id
        {
            for (int i = 0; i < listPost.Count; i++)
            {
                if (listPost[i].postID == postId)
                {
                    return listPost[i].postName;
                }
            }
            return "";
        }

        public static int findDivisionId(int divisionN) //найти id подразделения по наименованию
        {
            for (int i = 0; i < listDivision.Count; i++)
            {
                if (listDivision[i].divisionName == divisionN)
                {
                    return listDivision[i].divisionID;
                }
            }
            return -1;
        }

        public static int findDivisionName(int divisionId) //найти наименование по id
        {
            for (int i = 0; i < listDivision.Count; i++)
            {
                if (listDivision[i].divisionID == divisionId)
                {
                    return listDivision[i].divisionName;
                }
            }
            return -1;
        }

        public static int findTimeTableId(string timeTableN) //найти id графика работы по наименованию
        {
            for (int i = 0; i < listTimeTable.Count; i++)
            {
                if (listTimeTable[i].timeTableName == timeTableN)
                {
                    return listTimeTable[i].timeTableID;
                }
            }
            return -1;
        }

        public static string findTimeTableName(int timeTableId) //найти наименование по id
        {
            for (int i = 0; i < listTimeTable.Count; i++)
            {
                if (listTimeTable[i].timeTableID == timeTableId)
                {
                    return listTimeTable[i].timeTableName;
                }
            }
            return "";
        }

        public static int findWorkerId(string workerN) //найти id работника по наименованию
        {
            for (int i = 0; i < listWorker.Count; i++)
            {
                if (listWorker[i].FIO == workerN)
                {
                    return listWorker[i].workerID;
                }
            }
            return -1;
        }

        public static string findWorkerName(int workerId) //найти fio по id
        {
            for (int i = 0; i < listWorker.Count; i++)
            {
                if (listWorker[i].workerID == workerId)
                {
                    return listWorker[i].FIO;
                }
            }
            return "";
        }

        public static void saveSettings(int count, DateTime day, string time, string hours)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(connection);
            sqliteCon.Open();
            SQLiteCommand sqliteCom = new SQLiteCommand("DELETE FROM settings", sqliteCon);
            sqliteCom.ExecuteNonQuery();
            sqliteCom = new SQLiteCommand("INSERT INTO settings (countDays, dayStart, timeTable, timeWork) VALUES (" + count + ",'" + day + "','" + hours + "','" + time + "')", sqliteCon);           
            sqliteCom.ExecuteNonQuery();
            sqliteCon.Close();
            sqliteCon.Dispose();
        }

        public static Settings getSettings()
        {
            try
            {
                SQLiteConnection sqliteCon = new SQLiteConnection(connection);
                SQLiteCommand sqliteCom = new SQLiteCommand("SELECT * FROM settings", sqliteCon);
                sqliteCon.Open();
                SQLiteDataReader sqliteReader = sqliteCom.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(sqliteReader);
                sqliteCon.Close();
                sqliteCon.Dispose();
                Settings settings = new Settings(Convert.ToInt32(table.Rows[0][0]), Convert.ToDateTime(table.Rows[0][1]), table.Rows[0][2].ToString(), table.Rows[0][3].ToString());
                return settings;
            }
            catch
            {

            }
            return settings;                
        }
    }
}
