using System;
using System.Collections.Generic;

namespace OOPBasicsShared
{
    public interface IEncoderPlugin
    {
        String GetName();
        IEnumerable<String> GetRequiredArguments();
        void SetArguments(IDictionary<String, String> args);
        IEncoder GetEncoder();
    }
}
