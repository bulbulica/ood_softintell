using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Group : Shape
    {
        private List<Shape> allShapes = new List<Shape>();

        public Group(int identifier)
            : base(identifier)
        {
        }

        public void AddShape(Shape shape)
        {
            allShapes.Add(shape);
        }

        public override double ComputeArea()
        {
            double result = 0;
            foreach (var item in allShapes)
            {
                result += item.ComputeArea();
            }
            return result;
        }

        public List<Shape> GetAllShapes()
        {
            return allShapes;
        }

        public override string Name()
        {
            return "Grup";
        }

        /**
         * true if it already exists
         * false otherwise
         **/
        public bool CheckExistingIdentifierInGroup(int identifier)
        {
            foreach (var item in allShapes)
            {
                if (item.Identifier() == identifier)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
