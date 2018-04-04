using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppManager app = new AppManager();
            app.Initialize();
            app.RunApp();
        }
    }
}
