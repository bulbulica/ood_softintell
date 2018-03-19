using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicsEnigmaEncoder
{
    public class EnigmaPlugin : IEncoderPlugin
    {
        private List<String> arguments = new List<String>();
        private int startRange = 128;
        private int endRange = 255;
        private int randomValue = 112;

        public EnigmaPlugin()
        {
            arguments.Add("StartRange");
            arguments.Add("EndRange");
            arguments.Add("Random");
        }

        public IEncoder GetEncoder()
        {
            var retVal = new EnigmaEncoder(startRange, endRange, randomValue);
            return retVal;
        }

        public String GetName()
        {
            return "Enigma";
        }

        public IEnumerable<String> GetRequiredArguments()
        {
            return arguments;        
        }

        public void SetArguments(IDictionary<String, String> args)
        {
            startRange = Int32.Parse(args["StartRange"]);
            endRange = Int32.Parse(args["EndRange"]);
            randomValue = Int32.Parse(args["Random"]);
        }
    }
}
