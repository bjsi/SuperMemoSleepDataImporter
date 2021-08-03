using SleepDataImporter.Helpers;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SleepDataImporter.Models
{
    [StructLayout(LayoutKind.Sequential,
        Pack = 1,
        Size = 12)]
    public unsafe struct SleepDataStruct
    {
        /// <summary>
        /// DateTime expressed as a float where the integral part
        /// represents the number of days since Jan 1st 2000 and
        /// the fractional part represents the percentage of the day
        /// that has passed.
        /// </summary>
        public float Start;

        /// <summary>
        /// DateTime expressed as a float where the integral part
        /// represents the number of days since Jan 1st 2000 and
        /// the fractional part represents the percentage of the day
        /// that has passed.
        /// </summary>
        public float End;

        /// <summary>
        /// True if you woke up naturally without an alarm, waking up
        /// due to noisy neighbours etc.
        /// </summary>
        public byte NaturalWake;

        /// <summary>
        /// True if you went to bed not under the influence of
        /// alcohol, drugs, medication etc.
        /// </summary>
        public byte NaturalToBed;

        public SleepDataStruct(DateTime start, DateTime end, bool naturalWake = true, bool naturalToBed = true)
        {
            var s = start.AsSMFloatTime();
            var e = end.AsSMFloatTime();
            if (start > end)
                throw new InvalidDataException("Cannot create struct where start > end");

            Start = s;
            End = e;
            NaturalWake = Convert.ToByte(naturalWake);
            NaturalToBed = Convert.ToByte(naturalToBed);
        }

        public override string ToString()
        {
            return $"<Sleep Start={Start} End={End} NaturalWake={NaturalWake} NaturalToBed={NaturalToBed}>";
        }
    }
}
