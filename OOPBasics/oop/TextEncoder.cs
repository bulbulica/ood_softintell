using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public class TextEncoder
    {
        private IEncoder byteEncoder;

        public TextEncoder(IEncoder byteEncoder)
        {
            this.byteEncoder = byteEncoder;
        }

        public byte[] ByteEncoder(String inputData)
        {
            return byteEncoder.Encode(Encoding.ASCII.GetBytes(inputData));
        }
    }
}
