using SleepDataImporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class BinaryWriterTests
    {

        private readonly string TestPath = Path.Combine(Environment.CurrentDirectory, @"Fixtures/WRITE_TESTS_sleep.tim");

        // TODO: Test writing multiple blocks.
        // TODO: Where do the blocks get written to? At the end of the file?

        [Theory]
        [InlineData(new int[] { 2020, 09, 10, 10, 10, 0 }, new int[] { 2020, 09, 11, 11, 5, 0})]
        public void WriteToSleepFile(int[] s, int[] e)
        {
            File.Delete(TestPath);
            var sleepReg = new SleepDataRegistry(TestPath);
            var start = new DateTime(s[0], s[1], s[2], s[3], s[4], s[5]);
            var end = new DateTime(e[0], e[1], e[2], e[3], e[4], e[5]);
            var block = new SleepBlock(start, end);

            bool ret = sleepReg.WriteSleepData(new List<SleepBlock> { block });
            Assert.True(ret);

            var read = sleepReg.ReadSleepData();
            Assert.Equal(start, read[0].Start);
            Assert.Equal(end, read[0].End);
        }
    }
}
