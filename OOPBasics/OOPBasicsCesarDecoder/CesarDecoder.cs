using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsCesarEncoder
{
    public class CesarDecoder : IDecoder
    {
        private static readonly int offset = 3;

        public CesarDecoder()
        {
        }

        public byte[] Decode(byte[] inputData)
        {
            byte[] encodedInput = new byte[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i)
            {
                encodedInput[i] = DecodeByte(inputData[i]);
            }
            return encodedInput;
        }

        private byte DecodeByte(byte byteToDecode)
        {
            return (byte)((byteToDecode + 26 - offset) % 128);
        }
    }
}
