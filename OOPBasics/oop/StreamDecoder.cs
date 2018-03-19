using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPBasics
{
    class StreamDecoder
    {
        private TextDecoder textDecoder;
        private TextReader reader;

        public StreamDecoder(TextReader reader, TextDecoder textDecoder)
        {
            this.reader = reader;
            this.textDecoder = textDecoder;
        }

        public byte[] Decode()
        {
            String readedLine;
            String allText = "";

            while ((readedLine = reader.ReadLine()) != null)
            {
                allText += readedLine;
            }

            return textDecoder.ByteEncoder(allText);
        }

        public void Decode(BinaryWriter writer)
        {
            String readedLine;

            while ((readedLine = reader.ReadLine()) != null)
            {
                writer.Write(textDecoder.ByteEncoder(readedLine));
            }
        }
    }
}
