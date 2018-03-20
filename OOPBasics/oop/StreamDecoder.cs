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
            byte[] allBytes = reader.ReadBytes(int.MaxValue);

            return textDecoder.Decode(allBytes);
        }

        public void Decode(TextWriter writer)
        {
            byte[] readedBytes = reader.ReadBytes(int.MaxValue);

            writer.Write(textDecoder.Decode(readedBytes));
        }
    }
}
