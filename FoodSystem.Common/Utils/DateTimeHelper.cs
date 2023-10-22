using FoodSystem.Common.Enums;
using FoodSystem.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Utils
{
    public static class DateTimeHelper
    {
        public static List<DateTime> GetBeetwenDatesByPeriodicities(DateTime start, DateTime end, IntervalPeriodicity periodicity)
        {
            if(start > end)
                throw new StartIntevalLargerEnd(typeof(DateTimeHelper).FullName!);
            
            List<DateTime> result = new List<DateTime>();

            while(start < end)
            {
                result.Add(start);
                start = start.AddPeriodicityPeriods(periodicity, 1);
            }

            return result;
        }
    }
}
