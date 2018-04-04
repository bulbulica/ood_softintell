using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Rectangle : Shape
    {
        public Rectangle(Dictionary<String, object> values, int identifier)
            : base(identifier)
        {
            SetData(values);
        }

        public override double ComputeArea()
        {
            double result;
            double latura1 = (double)GetSpecificData("Latura1");
            double latura2 = (double)GetSpecificData("Latura2");
            result = latura1 * latura2;
            return result;
        }

        public override string Name()
        {
            return "Dreptunghi";
        }
    }
}
