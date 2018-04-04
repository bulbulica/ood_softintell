using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualApp
{
    public class Canvas
    {
        private List<Shape> allShapes;
        private List<Group> allGroups;

        public Canvas()
        {
            allShapes = new List<Shape>();
            allGroups = new List<Group>();

            DummyData();
        }

        private void DummyData()
        {
            Dictionary<String, object> values = new Dictionary<string, object>();
            values.Add("Raza", 4.0);
            values.Add("Centrul cercului", new Tuple<double, double>(2, 3));
            Shape circle = new Circle(values, 1);
            allShapes.Add(circle);

            Dictionary<String, object> valuess = new Dictionary<string, object>();
            valuess.Add("Latura1", (double)5);
            valuess.Add("Latura2", (double)4);
            Shape rectangle = new Rectangle(valuess, 2);
            allShapes.Add(rectangle);

            Group group = new Group(3);
            group.AddShape(new Circle(values, 4));
            group.AddShape(new Rectangle(valuess, 5));
            allGroups.Add(group);
        }

        public void AddNewShape(Shape shape)
        {
            allShapes.Add(shape);
        }

        public void AddNewGroup(Group group)
        {
            allGroups.Add(group);
        }

        public void AddNewShapeToGroup(Shape shape, int identifier)
        {
            allGroups[identifier].AddShape(shape);
        }

        public List<Shape> GetAllShapes()
        {
            return allShapes;
        }

        public List<Group> GetAllGroups()
        {
            return allGroups;
        }

        /**
         * true if it already exists
         * false otherwise
         **/
        public bool CheckExistingIdentifier(int identifier)
        {
            foreach (var item in allShapes)
            {
                if (item.Identifier() == identifier)
                {
                    return true;
                }
            }
            foreach (var item in allGroups)
            {
                if (item.Identifier() == identifier)
                {
                    return true;
                }
            }
            foreach (var item in allGroups)
            {
                if (item.CheckExistingIdentifierInGroup(identifier) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Group index, if doesn't exit return -1
         **/
        public int GetGroupIndex(int identifier)
        {
            for (int index = 0; index < allGroups.Count; ++index)
            {
                if (allGroups[index].Identifier() == identifier)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
