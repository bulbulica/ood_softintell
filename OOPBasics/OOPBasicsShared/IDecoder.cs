using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsShared
{
    public interface IDecoder
    {
        byte[] Decode(byte[] inputData);
    }
}
