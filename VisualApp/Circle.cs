using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Circle : Shape
    {
        private const double pi = 3.1415;

        public Circle(Dictionary<String, object> values, int identifier)
            : base(identifier)
        {
            SetData(values);
        }

        public override double ComputeArea()
        {
            double result;
            double raza = (double)GetSpecificData("Raza");
            result = raza * raza * pi;
            return result;
        }

        public override string Name()
        {
            return "Cerc";
        }
    }
}
