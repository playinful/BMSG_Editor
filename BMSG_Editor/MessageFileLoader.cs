using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSG_Editor
{
    public static class MessageFileLoader
    {
        public static MessageFile Open(string filename)
        {
            byte[] data = File.ReadAllBytes(filename);

            if (!(GetInt(data, 0) == 0 && GetInt(data, 4) <= GetInt(data, 8) && GetInt(data, 12) == 0))
                throw new Exception("Checksum failed; this is not a valid BMSG file.");

            MessageFile file = new()
            {
                Path = filename,
                Raw = data
            };

            int message_start_index = GetInt(data, 4);
            file.MessageStartIndex = message_start_index;
            int message_end_index = data.Length - message_start_index;

            file.Title = GrabString(data, message_start_index);

            int pointer_index = 0x24;

            while (pointer_index < message_start_index)
            {
                Console.WriteLine(pointer_index);

                if (GetInt(data, pointer_index) >= message_end_index || GetInt(data, pointer_index) < 0)
                    break;

                string key = GrabString(data, GetInt(data, pointer_index) + message_start_index);
                string value = GrabString(data, GetInt(data, pointer_index + 8) + message_start_index);

                file.Contents.Add(new(key, value));

                pointer_index += 12;
            }

            //Console.WriteLine(file);

            return file;
        }

        private static int GetInt(byte[] data, int index)
        {
            return BitConverter.ToInt32(data, index);
        }
        private static string GrabString(byte[] data, int index)
        {
            List<byte> chunk = new();

            for (int i = index; i < data.Length; i += 2)
            {
                if (i + 1 >= data.Length || i < 0)
                    break;

                if (data[i] == 0 && data[i + 1] == 0)
                    break;

                chunk.Add(data[i]);
                chunk.Add(data[i + 1]);
            }

            string str = Encoding.Unicode.GetString(chunk.ToArray()).ReplaceLineEndings();

            return str;
        }
    }
}
