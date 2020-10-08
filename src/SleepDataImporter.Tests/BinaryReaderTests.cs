using SleepDataImporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class BinaryReaderTests
    {

        private readonly string TestPath = Path.Combine(Environment.CurrentDirectory, "READ_TESTS_sleep.txt");
        private readonly List<SleepBlock> Expected = new List<SleepBlock>
        {
            new SleepBlock(new DateTime(2020, 9, 26, 0, 34, 0), new DateTime(2020, 9, 26, 4, 36, 0))
        };

        [Fact]
        public void ReadFromSleepFile()
        {
            var sleepReg = new SleepDataRegistry(TestPath);
            var actual = sleepReg.ReadSleepData();
            Assert.Equal(Expected, actual);
        }
    }
}
