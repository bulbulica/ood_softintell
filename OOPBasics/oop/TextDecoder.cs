using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    class TextDecoder
    {
        private IDecoder byteDecoder;

        public TextDecoder(IDecoder byteDecoder)
        {
            this.byteDecoder = byteDecoder;
        }

        public byte[] ByteEncoder(String inputData)
        {
            return byteDecoder.Decode(Encoding.ASCII.GetBytes(inputData));
        }
    }
}
