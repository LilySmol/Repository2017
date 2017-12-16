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
    }
}
