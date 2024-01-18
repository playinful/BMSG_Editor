using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.Pkcs;
using System.Xml.Linq;

namespace BMSG_Editor
{
    public class MessageFile
    {
        public byte[] Raw { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public List<Tuple<string, string>> Contents { get; set; } = new();
        public int MessageStartIndex { get; set; }
        public bool Modified { get; set; } = false;

        public void Save(string path)
        {
            Path = path;

            List<byte> outdata = Raw[..MessageStartIndex].ToList();
            outdata.AddRange(Encoding.Unicode.GetBytes(Title.Replace(Environment.NewLine, "\n")));
            outdata.Add(0);
            outdata.Add(0);

            for (int i = 0; i < Contents.Count; i++)
            {
                Extensions.SetBytes(outdata, 0x24 + i * 12, BitConverter.GetBytes(outdata.Count - MessageStartIndex));
                List<byte> bytes_to_append = Encoding.Unicode.GetBytes(Contents[i].Item1).ToList();
                bytes_to_append.Add(0);
                bytes_to_append.Add(0);
                outdata.AddRange(bytes_to_append);

                Extensions.SetBytes(outdata, 0x24 + i * 12 + 8, BitConverter.GetBytes(outdata.Count - MessageStartIndex));
                bytes_to_append = Encoding.Unicode.GetBytes(Contents[i].Item2).ToList();
                bytes_to_append.Add(0);
                bytes_to_append.Add(0);
                outdata.AddRange(bytes_to_append);
            }

            Extensions.SetBytes(outdata, 8, BitConverter.GetBytes(outdata.Count - MessageStartIndex));

            File.WriteAllBytes(path, outdata.ToArray());

            Modified = false;
        }
    }
}
