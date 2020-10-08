﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SleepDataImporter.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
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
        /// TODO: Is there a better way to specify padding?
        /// Four bytes of padding between each entry.
        /// </summary>
        public fixed byte Padding[4];
    }
}
