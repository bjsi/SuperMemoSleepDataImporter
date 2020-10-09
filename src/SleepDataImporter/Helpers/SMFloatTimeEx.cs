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
            return (date + time).RoundToNearest(TimeSpan.FromMinutes(1));
        }

        private static DateTime CalculateDate(float time)
        {
            var daysSinceBase = Math.Floor(time);
            return Constants.BaseDate.AddDays(daysSinceBase - 1);
        }

        private static TimeSpan CalculateTime(float time)
        {
            //float percent = (float)Math.Round(time % 1, 3);
            float percent = time % 1;
            var converted = TimeSpan.FromDays(percent);
            return converted;
        }
    }
}
