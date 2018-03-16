using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public class EnigmaEncoder : IEncoder
    {
        private int startRange;
        private int endRange;
        private int random;

        public EnigmaEncoder(int startRange, int endRange, int random)
        {
            this.startRange = startRange;
            this.endRange = endRange;
            this.random = random;
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
            return (byte)((startRange + (byteToEncode + random)) % (endRange - startRange));
        }
    }
}
