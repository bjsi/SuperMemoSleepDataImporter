using System.IO;
using System.Runtime.InteropServices;

namespace SleepDataImporter.Models
{
    public static class BinaryReaderEx
    {
        public static T ReadStruct<T>(this BinaryReader r)
        {
            byte[] rawData = r.ReadBytes(Marshal.SizeOf(typeof(T)));

            var pinnedRawData = GCHandle.Alloc(rawData,
                                               GCHandleType.Pinned);
            try
            {
                // Get the address of the data array
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();

                // overlay the data type on top of the raw data
                return (T)Marshal.PtrToStructure(pinnedRawDataPtr, typeof(T));
            }
            finally
            {
                // must explicitly release
                pinnedRawData.Free();
            }
        }
    }
}
