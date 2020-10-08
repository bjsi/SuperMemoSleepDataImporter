﻿using SleepDataImporter.Helpers;
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
