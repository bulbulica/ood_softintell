using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public interface IEncoder
    {
        byte[] Encode(byte[] inputData);
    }
}
