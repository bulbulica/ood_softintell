using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsShared
{
    public interface IEncoder
    {
        byte[] Encode(byte[] inputData);
    }
}
