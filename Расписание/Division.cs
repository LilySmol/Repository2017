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
    }
}
