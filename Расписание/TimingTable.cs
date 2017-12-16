using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class TimingTable
    {
        int timingID;
        int workerID;
        DateTime data;
        string hours;

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
