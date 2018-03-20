using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    public class TextDecoder
    {
        private IDecoder byteDecoder;

        public TextDecoder(IDecoder byteDecoder)
        {
            this.byteDecoder = byteDecoder;
        }

        public String Decode(byte[] inputData)
        {
            return byteDecoder.Decode(inputData);
        }
    }
}
