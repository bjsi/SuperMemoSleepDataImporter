using System;
using System.Collections.Generic;
using System.Text;

namespace SleepDataImporter.Helpers
{
    public static class TimeEx
    {
        public static TimeSpan RoundSeconds(this TimeSpan span)
        {
            return TimeSpan.FromSeconds(Math.Round(span.TotalSeconds));
        }
    }
}
