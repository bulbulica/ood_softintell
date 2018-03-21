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

        public String Decode(byte[] inputData)
        {
            String encodedInput = "";
            for (int i = 0; i < inputData.Length; ++i)
            {
                encodedInput += DecodeByte(inputData[i]);
            }
            return encodedInput;
        }

        private char DecodeByte(byte byteToDecode)
        {
            return (char)(byteToDecode - offset);
        }
    }
}
