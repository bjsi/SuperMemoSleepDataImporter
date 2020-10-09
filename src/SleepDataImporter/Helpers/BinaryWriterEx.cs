using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SleepDataImporter.Helpers
{
    public static class BinaryWriterEx
    {

        // TODO: Check this is correct
        // TODO: Is it better to use BinaryFormatter?

        public static bool WriteStruct<T>(this BinaryWriter w, T obj)
        {
            byte[] buffer = new byte[Marshal.SizeOf(obj)];
            var pinnedRawData = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            try
            {
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();
                Marshal.StructureToPtr(obj, pinnedRawDataPtr, true);
                
                // TODO: Will this write at the correct position in teh file?
                w.Write(buffer, 0, buffer.Length);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to write struct with exception {e}");
                return false;
            }
            finally
            {
                pinnedRawData.Free();
            }
        }
    }
}
