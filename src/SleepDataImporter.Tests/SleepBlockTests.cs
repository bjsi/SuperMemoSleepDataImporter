using SleepDataImporter.Helpers;
using SleepDataImporter.Models;
using System;
using System.IO;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class SleepBlockTests
    {

        [Fact]
        public void CreateValidSleepBlockSucceeds()
        {
            var start = new DateTime(2020, 09, 10, 10, 10, 01);
            var end = new DateTime(2020, 09, 11, 11, 5, 4);
            var block = new SleepBlock(start, end); // should not throw

            Assert.Equal(start, block.Start);
            Assert.Equal(end, block.End);
        }

        [Fact]
        public void CreateValidSleepBlockFromStructSucceeds()
        {
            var start = new DateTime(2020, 09, 10, 10, 10, 01).RoundToNearest(TimeSpan.FromMinutes(1));
            var end = new DateTime(2020, 09, 11, 11, 5, 4).RoundToNearest(TimeSpan.FromMinutes(1));
            var struc = new SleepDataStruct(start, end);
            Assert.Equal(start, struc.Start.AsDateTime());
            Assert.Equal(end, struc.End.AsDateTime());

            var block = new SleepBlock(ref struc);

            Assert.Equal(start, block.Start);
            Assert.Equal(end, block.End);
            Assert.Equal(struc.Start.AsDateTime(), block.Start);
            Assert.Equal(struc.End.AsDateTime(), block.End);
        }

        [Fact]
        public void CreateInvalidSleepBlockThrows()
        {
            // Start later than end
            var start = new DateTime(2020, 09, 10);
            var end = new DateTime(2020, 09, 09);

            Assert.Throws<InvalidDataException>(() => new SleepBlock(start, end));
        }
    }
}
