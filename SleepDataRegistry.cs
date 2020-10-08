using SleepDataImporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SleepDataImporter
{
    public class SleepDataRegistry
    {

        private readonly string SleepData;

        public SleepDataRegistry(string filepath)
        {
            this.SleepData = filepath;
        }

        // TODO: Some way of checking SM is running?
        // check if the file is locked or something?
        public void WriteSleepData(List<SleepBlock> blocks)
        {
            throw new NotImplementedException();
        }

        public void ReadSleepData()
        {
            using (Stream stream = File.OpenRead(SleepData))
            {
                var sleepBlocks = ParseSleepStream(stream);
                foreach (var block in sleepBlocks)
                    Console.WriteLine(block);
            }
        }

        public List<SleepBlock> ParseSleepStream(Stream stream)
        {
            List<SleepBlock> ret = new List<SleepBlock>();

            using (BinaryReader binStream = new BinaryReader(stream, Encoding.Default))
            {
                while (binStream.BaseStream.Position < binStream.BaseStream.Length)
                {
                    var sleepBlock = binStream.ReadStruct<SleepDataStruct>();
                    ret.Add(new SleepBlock(ref sleepBlock));
                }
            }

            return ret;
        }
    }
}
