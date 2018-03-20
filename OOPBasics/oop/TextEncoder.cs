using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    public class TextEncoder
    {
        private IEncoder byteEncoder;

        public TextEncoder(IEncoder byteEncoder)
        {
            this.byteEncoder = byteEncoder;
        }

        public byte[] Encode(String inputData)
        {
            return byteEncoder.Encode(Encoding.ASCII.GetBytes(inputData));
        }
    }
}
