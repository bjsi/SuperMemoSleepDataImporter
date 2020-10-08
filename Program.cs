using System;

namespace SleepDataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\james\SuperMemo\sleep\sleep.tim";
            var sleepReg = new SleepDataRegistry(file);
            sleepReg.ReadSleepData();
        }
    }
}
