using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class TimingTable
    {
        public int timingID;
        public int workerID;
        public DateTime data;
        public string hours;

        public TimingTable()
        { }
        
        public TimingTable(int id, int workerid, DateTime date, string hour)
        {
            timingID = id;
            workerID = workerid;
            data = date;
            hours = hour;
        }
    }
}
