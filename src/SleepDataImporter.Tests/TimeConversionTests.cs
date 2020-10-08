using SleepDataImporter.Helpers;
using System;
using System.Net.Http.Headers;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class TimeConversionTests
    {
        [Theory]
        [InlineData(7575.191, new int[] { 2020, 9, 26, 0, 10, 0 } )]
        [InlineData(7575.024, new int[] { 2020, 9, 26, 0, 10, 0 } )]
        public static void SMFloatTimeConvertsToDateTime(float input, int[] ar)
        {
            var expected = new DateTime(ar[0], ar[1], ar[2], ar[3], ar[4], ar[5]);
            var actual = input.AsDateTime();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(7575.191, new int[] { 2020, 9, 26, 0, 10, 0 } )]
        [InlineData(7575.024, new int[] { 2020, 9, 26, 0, 10, 0 } )]
        public static void DateTimeConvertsToSMFloatTime(float expected, int[] ar)
        {
            var input = new DateTime(ar[0], ar[1], ar[2], ar[3], ar[4], ar[5]);
            var actual = input.AsSMFloatTime();
            Assert.Equal(expected, actual);
        }
    }
}
