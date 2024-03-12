using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository.Utils
{
    public static class Calculate
    {
        public static int[] CalculateParkingTime(DateTime? checkin, DateTime? checkout)
        {
            TimeSpan timeSpan = ((DateTime)checkout).Subtract((DateTime)checkin);

            int[] parkingTime = new int[]
            {
                timeSpan.Hours,
                timeSpan.Days % 365 % 30 % 7,
                timeSpan.Days % 365 % 30 / 7,
                timeSpan.Days % 365 / 30,
                timeSpan.Days / 365
            };

            return parkingTime;
        }
    }
}
