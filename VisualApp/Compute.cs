using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Compute
    {
        public double ToDouble(String value)
        {
            if (value == null)
            {
                return 0;
            }
            return Double.Parse(value, CultureInfo.CurrentCulture);
        }

        public Int32 ToInt(String value)
        {
            if (value == null)
            {
                return 0;
            }
            return Convert.ToInt32(value);
        }
    }
}
