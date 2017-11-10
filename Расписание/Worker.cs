using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Worker
    {
        int workerID;
        string FIO;
        string phone;
        int divisionID;
        int postID;
        int hoursID;
        int timeTableID;

        public Worker(int id, string fio, string phone, int division, int post, int hours, int timeTable)
        {
            workerID = id;
            FIO = fio;
            this.phone = phone;
            divisionID = division;
            postID = post;
            hoursID = hours;
            timeTableID = timeTable;
        }
    }
}
