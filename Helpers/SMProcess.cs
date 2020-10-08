using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SleepDataImporter.Helpers
{
    public static class SMProcess
    {
        private static string[] ProcessNames = new string[]
        {
            "sm18",
        };

        public static bool IsOpen()
        {
            if (ProcessNames.Any(x => Process.GetProcessesByName(x).Any()))
                return true;
            return false;
        }
    }
}
