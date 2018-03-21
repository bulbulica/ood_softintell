using OOPBasics;
using OOPBasicsShared;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace OOPBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            AppManager app = new AppManager();
            app.Initialize();
            app.RunApp();
        }
    }
}
