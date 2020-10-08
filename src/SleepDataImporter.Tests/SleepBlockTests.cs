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
            var start = new DateTime();
            var end = new DateTime();
            var block = new SleepBlock(start, end); // should not throw
        }

        [Fact]
        public void CreateInvalidSleepBlockThrows()
        {
            var start = new DateTime();
            var end = new DateTime();
            Assert.Throws<InvalidDataException>(() => new SleepBlock(start, end));
        }
    }
}
