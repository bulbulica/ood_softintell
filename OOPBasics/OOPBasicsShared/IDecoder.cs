using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsShared
{
    public interface IDecoder
    {
        String Decode(byte[] inputData);
    }
}
