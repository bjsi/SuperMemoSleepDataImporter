using SleepDataImporter.Helpers;
using System;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class TimeConversionTests
    {
        [Theory]
        [InlineData(7575.191, new int[] { 2020, 9, 26, 4, 35, 2 } )]
        [InlineData(7575.024, new int[] { 2020, 9, 26, 0, 34, 34 })]
        public static void SMFloatTimeConvertsToDateTime(float input, int[] ar)
        {
            var expected = new DateTime(ar[0], ar[1], ar[2], ar[3], ar[4], ar[5]);
            var actual = input.AsDateTime();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(7575.191, new int[] { 2020, 9, 26, 4, 35, 2 } )]
        [InlineData(7575.024, new int[] { 2020, 9, 26, 0, 34, 34 })]
        public static void DateTimeConvertsToSMFloatTime(float expected, int[] ar)
        {
            var input = new DateTime(ar[0], ar[1], ar[2], ar[3], ar[4], ar[5]);
            float actual = input.AsSMFloatTime();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(7575.191, new int[] { 2020, 9, 26, 4, 35, 2 } )]
        [InlineData(7575.024, new int[] { 2020, 9, 26, 0, 34, 34 })]
        public static void MultipleConversionsSucceed(float fl, int[] ar)
        {
            var input = new DateTime(ar[0], ar[1], ar[2], ar[3], ar[4], ar[5]);
            float actual = input.AsSMFloatTime();
            Assert.Equal(fl, actual);

            var dt = actual.AsDateTime();
            Assert.Equal(input, dt);
        }
    }
}
