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

        public int findHoursId(int hoursN, List<Hours> list) //найти id часов по наименованию
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].hoursName == hoursN)
                {
                    return list[i].hoursID;
                }
            }
            return -1;
        }

        public int findHoursName(int hoursId, List<Hours> list) //найти наименование по id
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].hoursID == hoursId)
                {
                    return list[i].hoursName;
                }
            }
            return -1;
        }
    }
}
