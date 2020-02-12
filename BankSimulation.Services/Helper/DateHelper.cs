using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Service.Helper
{
    public class DateHelper
    {
        public static string GetTodayDate(int formatType)
        {
            string date = DateTime.Now.ToString().Split(' ')[0];
            string[] formattedDate = date.Split('-');
            if (formatType == 1)
            {
                return date;
            }
            else
                return formattedDate[0] + formattedDate[1] + formattedDate[2];
        }
        public static string GetCurrentTime(int formatType)
        {
            string time = DateTime.Now.ToString().Split(' ')[1];
            string[] formattedTime = time.Split(':');
            if (formatType == 1)
                return time;
            else
                return formattedTime[0] + formattedTime[1] + formattedTime[2];
        }
    }
}
