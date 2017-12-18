using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class WorkWithSchedule
    {
        public List<TimingTable> listTiming = new List<TimingTable>();
        static List<Worker> listWorker = DBHelper.getWorkerList();

        public WorkWithSchedule() { }
        public void makeSchedule(int countDays, int hourStart, DateTime dayStart, string timeTable)
        {
            int days = Convert.ToInt32(timeTable.Split('/')[0]); //количество рабочих дней           
            int id = 1;                
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
            foreach (Worker worker in listWorker)
            {
                bool flag;
                DateTime day = dayStart;
                int countDaysTemp = countDays;
                string hours = hourStart.ToString() +"-"+ Convert.ToString(hourStart + DBHelper.findHoursName(worker.hoursID));
                flag = (worker.divisionID == 1) ? true : false;
                while (countDaysTemp != 0)
                {
                    for (int count = 0; count < days; count++)
                    {
                        if (flag)
                        {
                            listTiming.Add(new TimingTable(id, worker.workerID, day, hours));
                            countDaysTemp--;
                            id++;
                            day += oneDay;
                            if (count == days - 1)
                                flag = false;
                            if (countDaysTemp == 0)
                                break;
                        }
                        else
                        {
                            listTiming.Add(new TimingTable(id, worker.workerID, day, "0"));
                            countDaysTemp--;
                            id++;
                            day += oneDay;
                            if (count == days - 1)
                                flag = true;
                            if (countDaysTemp == 0)
                                break;
                        }
                    }
                }                               
            }
        }
    }
}
