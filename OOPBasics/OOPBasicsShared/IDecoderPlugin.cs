using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsShared
{
    public interface IDecoderPlugin
    {
        String GetName();
        IEnumerable<String> GetRequiredArguments();
        void SetArguments(IDictionary<String, String> args);
        IDecoder GetDecoder();
    }
}
