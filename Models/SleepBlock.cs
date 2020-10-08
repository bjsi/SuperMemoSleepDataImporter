using SleepDataImporter.Helpers;
using System;
using System.IO;

namespace SleepDataImporter.Models
{
    public class SleepBlock
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public SleepBlock(ref SleepDataStruct block)
        {
            var start = block.Start.AsDateTime();
            var end = block.End.AsDateTime();
            if (start > end)
                throw new InvalidDataException("Cannot create a sleep block where start time > end time");

            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return $"Start = {Start}; End = {End};";
        }
    }
}
