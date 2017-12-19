using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Worker
    {
        public int workerID;
        public string FIO;
        public string phone;
        public int divisionID;
        public int postID;
        public int hoursID;

        public Worker(int id, string fio, string phone, int division, int post, int hours)
        {
            workerID = id;
            FIO = fio;
            this.phone = phone;
            divisionID = division;
            postID = post;
            hoursID = hours;
        }
    }
}
