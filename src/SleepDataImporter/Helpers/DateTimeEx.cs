﻿using System;

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
            var hms = Math.Round(CalculateTime(input), 3);
            return (float)(days + hms);
        }

        private static float CalculateDate(DateTime time)
        {
            return (time - Constants.BaseDate).Days + 1;
        }

        private static float CalculateTime(DateTime time)
        {
            float secondsInADay = 24 * 60 * 60;
            float hours = time.Hour * 60 * 60;
            float minutes = time.Minute * 60;
            float seconds = time.Second;
            float milliseconds = (float)Math.Round((float)time.Millisecond / 1000);

            float totalSeconds = hours + minutes + seconds + milliseconds;
            return (float)totalSeconds / secondsInADay;
        }
    }
}
