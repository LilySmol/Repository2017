using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class TimeTableHelp
    {
        public int timeTableID;
        public string timeTableName;

        public TimeTableHelp()
        {

        }

        public TimeTableHelp(int id, string timeTable)
        {
            timeTableID = id;
            timeTableName = timeTable;
        }

        public int findTimeTableId(string timeTableN, List<TimeTableHelp> list) //найти id графика работы по наименованию
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].timeTableName == timeTableN)
                {
                    return list[i].timeTableID;
                }
            }
            return -1;
        }

        public string findTimeTableName(int timeTableId, List<TimeTableHelp> list) //найти наименование по id
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].timeTableID == timeTableId)
                {
                    return list[i].timeTableName;
                }
            }
            return "";
        }
    }
}
