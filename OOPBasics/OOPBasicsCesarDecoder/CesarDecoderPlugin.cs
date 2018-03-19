using OOPBasicsCesarEncoder;
using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsCesarDecoder
{
    public class CesarDecoderPlugin : IDecoderPlugin
    {
        public CesarDecoderPlugin()
        {
        }

        public IDecoder GetDecoder()
        {
            var retVal = new CesarDecoder();
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
