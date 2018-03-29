using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Main
{
    public sealed class Logger
    {
        private static Logger instance = new Logger();

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                return instance;
            }
        }

        public void LogInfo(TextWriter textWriter, String text)
        {
            textWriter.Write("Info  : {0}\n", text);
        }

        public void LogError(TextWriter textWriter, String text)
        {
            textWriter.Write("Error : {0}\n", text);
        }

        public void LogWarning(TextWriter textWriter, String text)
        {
            textWriter.Write("Warning : {0}\n", text);
        }
    }
}
