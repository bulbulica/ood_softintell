using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsCesarEncoder
{
    public class CesarEncoderPlugin : IEncoderPlugin
    {
        public CesarEncoderPlugin()
        {
        }

        public IEncoder GetEncoder()
        {
            var retVal = new CesarEncoder();
            return retVal;
        }

        public String GetName()
        {
            return "Cesar";
        }

        public IEnumerable<String> GetRequiredArguments()
        {
            return new List<String>();
        }

        public void SetArguments(IDictionary<String, String> args)
        {
        }
    }
}
