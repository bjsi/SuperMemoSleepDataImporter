using SleepDataImporter.Helpers;
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

        public bool WriteSleepData(List<SleepBlock> blocks)
        {
            if (SMProcess.IsOpen())
            {
                Console.WriteLine("Failed to write sleep data because there is a running SuperMemo process");
                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(SleepData)))
            {
                foreach (var block in blocks)
                {
                    var sleepStruct = new SleepDataStruct(block.Start, block.End);
                    if (!writer.WriteStruct(sleepStruct))
                    {
                        return false;
                    }
                }

                return true;
            }

        }

        public List<SleepBlock> ReadSleepData()
        {
            try
            {
                using (Stream stream = File.OpenRead(SleepData))
                {
                    return ParseSleepStream(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to Read sleep data with exception {e}");
                return null;
            }
        }

        public List<SleepBlock> ParseSleepStream(Stream stream)
        {
            List<SleepBlock> ret = new List<SleepBlock>();

            using (BinaryReader binStream = new BinaryReader(stream, Encoding.Default))
            {
                int skipped = 0;
                while (binStream.BaseStream.Position < binStream.BaseStream.Length)
                {
                    try
                    {
                        var sleepBlock = binStream.ReadStruct<SleepDataStruct>();
                        ret.Add(new SleepBlock(ref sleepBlock));
                    }
                    catch (InvalidDataException)
                    {
                        skipped++;
                    }
                }

                Console.WriteLine($"{skipped} invalid sleep blocks (start > end) were skipped");

            }

            return ret;
        }
    }
}
