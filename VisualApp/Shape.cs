using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public abstract class Shape
    {
        private Dictionary<String, object> values = new Dictionary<String, object>();
        private int identifier;

        public Shape(int identifier)
        {
            this.identifier = identifier;
        }

        public int Identifier()
        {
            return identifier;
        }

        public void SetData(Dictionary<String, object> values)
        {
            this.values = values;
        }

        public Dictionary<String, object> Data()
        {
            return values;
        }

        public object GetSpecificData(String key)
        {
            return values[key];
        }

        abstract public String Name();
        abstract public double ComputeArea();
    }
}
