using System;
using System.Collections.Generic;
using System.Text;

namespace SleepDataImporter.Helpers
{
    public static class DateTimeEx
    {
        /// <summary>
        /// Converts DateTime to SM Float Time
        /// </summary>
        public static float AsSMFloatTime(this DateTime input)
        {
            var days = CalculateDate(input);
            var hms = CalculateTime(input);
            return days + hms;
        }

        private static float CalculateDate(DateTime time)
        {
            return (time  - Constants.BaseDate).Days + 1;
        }

        private static float CalculateTime(DateTime time)
        {
            var secondsInADay = 24 * 60 * 60;
            var hours = time.Hour * 60 * 60;
            var minutes = time.Minute * 60;
            var seconds = time.Second;
            // TODO: Need milliseconds?

            var totalSeconds = hours + minutes + seconds;
            return (float)totalSeconds / secondsInADay;
        }
    }
}
