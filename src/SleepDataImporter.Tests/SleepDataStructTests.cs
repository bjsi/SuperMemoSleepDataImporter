using SleepDataImporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SleepDataImporter.Tests
{
    public class SleepDataStructTests
    {

        [Fact]
        public void CreateValidSleepDataStructSucceeds()
        {
            var start = new DateTime();
            var end = new DateTime();
            var struc = new SleepDataStruct(start, end); // should not throw
        }

        [Fact]
        public void CreateInvalidSleepDataStructThrows()
        {
            var start = new DateTime();
            var end = new DateTime();
            Assert.Throws<InvalidDataException>(() => new SleepDataStruct(start, end));
        }
    }
}
