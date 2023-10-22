using FoodSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Common.Utils
{
    public static class DateTimeExtension
    {
        private static DateTime ExtractDate(DateTime dateTime, IntervalPeriodicity periodicity)
        {
            switch (periodicity)
            {
                case IntervalPeriodicity.Decade:
                    {
                        dateTime = dateTime.AddYears(-dateTime.Year % 10);
                        goto case IntervalPeriodicity.Year;
                    }
                case IntervalPeriodicity.Year:
                    {
                        dateTime = dateTime.AddMonths(-dateTime.Month + 1);
                        goto case IntervalPeriodicity.Month;
                    }
                case IntervalPeriodicity.Month:
                    {
                        dateTime = dateTime.AddDays(-dateTime.Day + 1);

                        dateTime = dateTime.AddHours(-dateTime.Hour);
                        dateTime = dateTime.AddMinutes(-dateTime.Minute);
                        dateTime = dateTime.AddSeconds(-dateTime.Second);
                        dateTime = dateTime.AddMilliseconds(-dateTime.Millisecond);
                        break;
                    }
            }
            return dateTime;
        }

        public static DateTime AddPeriodicityPeriods(this DateTime dateTime, IntervalPeriodicity periodicity, int periods)
        {
            switch(periodicity)
            {
                case IntervalPeriodicity.Decade:
                    {
                        dateTime = dateTime.AddYears(periods * 10);
                        break;
                    }
                case IntervalPeriodicity.Year:
                    {
                        dateTime = dateTime.AddYears(periods);
                        break;
                    }
                case IntervalPeriodicity.Month:
                    {
                        dateTime = dateTime.AddMonths(periods);
                        break;
                    }
                case IntervalPeriodicity.Day:
                    {
                        dateTime = dateTime.AddDays(periods);
                        break;
                    }
            }
            return dateTime;
        }
        public static DateTime SubtractPeriodicityPeriods(this DateTime dateTime, IntervalPeriodicity periodicity, int periods)
        {
            switch (periodicity)
            {
                case IntervalPeriodicity.Decade:
                    {
                        dateTime = dateTime.AddYears(-periods * 10);
                        break;
                    }
                case IntervalPeriodicity.Year:
                    {
                        dateTime = dateTime.AddYears(-periods);
                        break;
                    }
                case IntervalPeriodicity.Month:
                    {
                        dateTime = dateTime.AddMonths(-periods);
                        break;
                    }
                case IntervalPeriodicity.Day:
                    {
                        dateTime = dateTime.AddDays(-periods);
                        break;
                    }
            }
            return dateTime;
        }

        public static DateTime ToStartByPeriodicity(this DateTime d, IntervalPeriodicity periodicity)
        {
            return ExtractDate(d, periodicity);
        }
        public static DateTime ToEndByPeriodicity(this DateTime d, IntervalPeriodicity periodicity)
        {
            return AddPeriodicityPeriods(ExtractDate(d, periodicity), periodicity, 1).AddMilliseconds(-1);
        }
        public static int GetDayInWeek(this DateTime dateTime)
        {
            int day = (int)dateTime.DayOfWeek;
            if (day == 0) day = 6;
            else day -= 1;
            return day;
        }
    }
}
