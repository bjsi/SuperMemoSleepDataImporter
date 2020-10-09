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
            var date = CalculateDate(input);
            var time = CalculateTime(input);
            return date + time;
        }

        private static DateTime CalculateDate(float time)
        {
            var daysSinceBase = Math.Floor(time);
            return Constants.BaseDate.AddDays(daysSinceBase - 1);
        }

        private static TimeSpan CalculateTime(float time)
        {
            float percent = (float)Math.Round(time % 1, 3);
            return TimeSpan.FromDays(percent).RoundSeconds();
        }
    }
}
