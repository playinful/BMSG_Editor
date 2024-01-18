using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSG_Editor
{
    public static class Extensions
    {
        public static bool SetBytes(Span<byte> data, byte[] value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = value[i];
            }
            return true;
        }
        public static bool SetBytes(List<byte> data, int index, byte[] value)
        {
            for (int i = 0; i + index < data.Count && i < value.Length; i++)
            {
                data[index + i] = value[i];
            }
            return true;
        }
    }
}
