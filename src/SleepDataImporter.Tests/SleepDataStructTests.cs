using SleepDataImporter.Helpers;
using SleepDataImporter.Models;
using System;
using System.IO;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class SleepDataStructTests
    {

        [Theory]
        [InlineData(new int[] { 2020, 09, 10, 10, 10, 0 }, new int[] { 2020, 09, 11, 11, 5, 0})]
        [InlineData(new int[] { 2020, 09, 10, 10, 10, 0 }, new int[] { 2020, 09, 11, 11, 5, 0})]
        [InlineData(new int[] { 2020, 09, 10, 10, 10, 0 }, new int[] { 2020, 09, 11, 11, 5, 0})]
        [InlineData(new int[] { 2020, 09, 10, 10, 10, 0 }, new int[] { 2020, 09, 11, 11, 5, 0})]
        public void CreateValidSleepDataStructSucceeds(int[] start, int[] end)
        {
            var s = new DateTime(start[0], start[1], start[2], start[3], start[4], start[5]).RoundToNearest(TimeSpan.FromMinutes(1));
            var e = new DateTime(end[0], end[1], end[2], end[3], end[4], end[5]).RoundToNearest(TimeSpan.FromMinutes(1));
            var struc = new SleepDataStruct(s, e);

            Assert.Equal(e, struc.End.AsDateTime());
            Assert.Equal(s, struc.Start.AsDateTime());
        }

        [Fact]
        public void CreateInvalidSleepDataStructThrows()
        {
            // Start later than end
            var start = new DateTime(2020, 09, 10);
            var end = new DateTime(2020, 09, 09);

            Assert.Throws<InvalidDataException>(() => new SleepDataStruct(start, end));
        }
    }
}
