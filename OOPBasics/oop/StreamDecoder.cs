using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPBasics
{
    public class StreamDecoder
    {
        private TextDecoder textDecoder;
        private BinaryReader reader;

        public StreamDecoder(BinaryReader reader, TextDecoder textDecoder)
        {
            this.reader = reader;
            this.textDecoder = textDecoder;
        }

        public String Decode()
        {
            byte[] allBytes = reader.ReadBytes(4000000);

            return textDecoder.Decode(allBytes);
        }

        public void Decode(TextWriter writer)
        {
            int maxValue = 4000000;
            byte[] readedBytes = new byte[] { };
            while (true)
            {
                byte[] readBytes = reader.ReadBytes(maxValue);
                if (readBytes.Length > 0)
                {
                    readedBytes = readBytes;
                }
                else
                {
                    break;
                }
            }

            writer.Write(textDecoder.Decode(readedBytes));
        }
    }
}
