using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsCesarEncoder
{
    public class CesarEncoder : IEncoder
    {
        private static readonly int offset = 3;

        public CesarEncoder()
        {
        }

        public byte[] Encode(byte[] inputData)
        {
            byte[] encodedInput = new byte[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i)
            {
                encodedInput[i] = EncodeByte(inputData[i]);
            }
            return encodedInput;
        }

        private byte EncodeByte(byte byteToEncode)
        {
            return (byte)((byteToEncode + offset) % 128);
        }
    }
}
