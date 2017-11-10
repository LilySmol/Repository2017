using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Division
    {
        public int divisionID;
        public int divisionName;

        public Division()
        { }

        public Division(int id, int division)
        {
            divisionID = id;
            divisionName = division;
        }

        public int findDivisionId(int divisionN, List<Division> list) //найти id подразделения по наименованию
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].divisionName == divisionN)
                {
                    return list[i].divisionID;
                }
            }
            return -1;
        }

        public int findDivisionName(int divisionId, List<Division> list) //найти наименование по id
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].divisionID == divisionId)
                {
                    return list[i].divisionName;
                }
            }
            return -1;
        }
    }
}
