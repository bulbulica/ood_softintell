using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace oop
{
    public class StreamEncoder
    {
        private TextEncoder textEncoder;
        private TextReader reader;

        public StreamEncoder(TextReader reader, TextEncoder textEncoder)
        {
            this.reader = reader;
            this.textEncoder = textEncoder;
        }

        public byte[] Encode()
        {
            String readedLine;
            String allText = "";

            while ((readedLine = reader.ReadLine()) != null)
            {
                allText += readedLine;
            }

            return textEncoder.ByteEncoder(allText);
        }

        public void Encode(BinaryWriter writer)
        {
            String readedLine;

            while ((readedLine = reader.ReadLine()) != null)
            {
                writer.Write(textEncoder.ByteEncoder(readedLine));
            }
        }
    }
}
