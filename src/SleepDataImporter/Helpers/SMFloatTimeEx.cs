using System;

namespace SleepDataImporter.Helpers
{
    public static class SMFloatTimeEx
    {
        /// <summary>
        /// Converts SM Float time to DateTime
        /// </summary>
        public static DateTime AsDateTime(this float input)
        {
            return CalculateDate(input) + CalculateTime(input);
        }

        private static DateTime CalculateDate(float time)
        {
            var daysSinceBase = Math.Floor(time);
            return Constants.BaseDate.AddDays(daysSinceBase - 1);
        }

        private static TimeSpan CalculateTime(float time)
        {
            return TimeSpan.FromDays(time % 1);
        }
    }
}
