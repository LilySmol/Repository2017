using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Hours
    {
        public int hoursID;
        public int hoursName;

        public Hours()
        {

        }

        public Hours(int id, int hours)
        {
            hoursID = id;
            hoursName = hours;
        }        
    }
}
