using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Settings
    {
        public int countDays;
        public DateTime dayStart;
        public string timeTable;
        public string timeWork;

        public Settings() { }
        public Settings(int count, DateTime day, string table, string work)
        {
            countDays = count;
            dayStart = day;
            timeTable = table;
            timeWork = work;
        }
    }
}
