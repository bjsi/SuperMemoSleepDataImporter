using System;
using System.Collections.Generic;
using System.Text;

namespace SleepDataImporter.Models
{
    public class SleepBlock
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        /// <summary>
        /// The base date SM uses is January 1st 2000
        /// </summary>
        private DateTime BaseDate = new DateTime(2000, 1, 1);

        public SleepBlock(ref SleepDataStruct block)
        {
            // TODO: Throw error if start > end

            this.Start = this.ConvertFloatToDateTime(block.Start);
            this.End = this.ConvertFloatToDateTime(block.End);
        }

        public override string ToString()
        {
            return $"Start = {Start}; End = {End};";
        }

        private DateTime ConvertFloatToDateTime(float input)
        {
            return CalculateDate(input) + CalculateTime(input);
        }

        private DateTime CalculateDate(float time)
        {
            var daysSinceBase = Math.Floor(time);
            return BaseDate.AddDays(daysSinceBase - 1);
        }

        private TimeSpan CalculateTime(float time)
        {
            return TimeSpan.FromDays(time % 1);
        }
    }
}
