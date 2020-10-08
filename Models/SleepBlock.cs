using SleepDataImporter.Helpers;
using System;
using System.IO;

namespace SleepDataImporter.Models
{
    public class SleepBlock
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public SleepBlock(DateTime start, DateTime end) 
        {
            ThrowIfInvalid(start, end);

            this.Start = start;
            this.End = end;
        }

        public SleepBlock(ref SleepDataStruct block)
        {
            var start = block.Start.AsDateTime();
            var end = block.End.AsDateTime();
            ThrowIfInvalid(start, end);

            this.Start = start;
            this.End = end;
        }

        private void ThrowIfInvalid(DateTime start, DateTime end)
        {
            if (start > end)
                throw new InvalidDataException("Cannot create a sleep block where start time > end time");
        }

        public override string ToString()
        {
            return $"Start = {Start}; End = {End};";
        }
    }
}
