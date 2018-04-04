using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace VisualApp
{
    public class AppManager
    {
        Canvas canvas = new Canvas();
        ConsoleMenu menu = new ConsoleMenu();
        Compute compute = new Compute();

        public void Initialize()
        {
            menu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Deseneaza un cerc si adauga pe plansa", ActionToExecute = new MenuItemAction(AddNewCircle) });
            menu.AddItem(new MenuItem { ShortcutChar = '2', Text = "Deseneaza un cerc si adauga intr-un grup", ActionToExecute = new MenuItemAction(AddNewCircleToGroup) });
            menu.AddItem(new MenuItem { ShortcutChar = '3', Text = "Deseneaza un dreptunghi ", ActionToExecute = new MenuItemAction(AddNewRectangle) });
            menu.AddItem(new MenuItem { ShortcutChar = '4', Text = "Deseneaza un dreptunghi si adauga intr-un grup", ActionToExecute = new MenuItemAction(AddNewRectangleToGroup) });
            menu.AddItem(new MenuItem { ShortcutChar = '5', Text = "Creza un grup", ActionToExecute = new MenuItemAction(CreateNewGroup) });
            menu.AddItem(new MenuItem { ShortcutChar = '6', Text = "Afiseaza toata obiectele", ActionToExecute = new MenuItemAction(ListAllObjects) });
        }

        public void RunApp()
        {
            menu.Run();
        }

        private void AddNewCircle(object sender, object contextObject)
        {
            String radius = "Raza";
            String center = "Centrul cercului";
            double radiusNumber;
            Tuple<double, double> centerNumber;
            double firstCenter, secondCenter;
            int identifier;

            Console.WriteLine(radius + ": ");
            radiusNumber = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(center + " - first number: ");
            firstCenter = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(center + " - second number: ");
            secondCenter = compute.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }

            centerNumber = new Tuple<double, double>(firstCenter, secondCenter);
            Dictionary<String, object> circleData = new Dictionary<string, object>();

            circleData.Add(radius, radiusNumber);
            circleData.Add(center, centerNumber);

            Shape circle = new Circle(circleData, identifier);

            canvas.AddNewShape(circle);

            Console.WriteLine("Cercul a fost adaugat cu succes {0}", circle.ComputeArea());
            Console.Read();
        }

        private void AddNewCircleToGroup(object sender, object contextObject)
        {
            String radius = "Raza";
            String center = "Centrul cercului";
            String groupText = "Grup";
            double radiusNumber;
            Tuple<double, double> centerNumber;
            double firstCenter, secondCenter;
            int identifier, group;

            Console.WriteLine(radius + ": ");
            radiusNumber = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(center + " - first number: ");
            firstCenter = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(center + " - second number: ");
            secondCenter = compute.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }

            Console.WriteLine(groupText + ": ");
            group = compute.ToInt(Console.ReadLine());

            centerNumber = new Tuple<double, double>(firstCenter, secondCenter);
            Dictionary<String, object> circleData = new Dictionary<string, object>();

            circleData.Add(radius, radiusNumber);
            circleData.Add(center, centerNumber);

            Shape circle = new Circle(circleData, identifier);

            int groupIndex = canvas.GetGroupIndex(group);
            if (groupIndex > -1)
            {
                canvas.AddNewShapeToGroup(circle, groupIndex);
                Console.WriteLine("Cercul a fost adaugat cu succes in grup!");
            }
            else
            {
                Console.WriteLine("Cercul nu a fost adaugat in grup!");
            }
            Console.Read();
        }

        private void AddNewRectangle(object sender, object contextObject)
        {
            String latura1 = "Latura1";
            String latura2 = "Latura2";
            double laturaBig, laturaSmall;
            int identifier;

            Console.WriteLine(latura1 + ": ");
            laturaBig = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(latura2 + ": ");
            laturaSmall = compute.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }

            Dictionary<String, object> rectangleData = new Dictionary<string, object>();

            rectangleData.Add(latura1, laturaBig);
            rectangleData.Add(latura2, laturaSmall);

            Shape rectangle = new Rectangle(rectangleData, identifier);

            canvas.AddNewShape(rectangle);

            Console.WriteLine("Dreptunghiul a fost adaugat cu succes!");
            Console.Read();
        }

        private void AddNewRectangleToGroup(object sender, object contextObject)
        {
            String latura1 = "Latura1";
            String latura2 = "Latura2";
            String groupText = "Grup";
            double laturaBig, laturaSmall;
            int identifier, group;

            Console.WriteLine(latura1 + ": ");
            laturaBig = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(latura2 + ": ");
            laturaSmall = compute.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }

            Console.WriteLine(groupText + ": ");
            group = compute.ToInt(Console.ReadLine());

            Dictionary<String, object> rectangleData = new Dictionary<string, object>();

            rectangleData.Add(latura1, laturaBig);
            rectangleData.Add(latura2, laturaSmall);

            Shape rectangle = new Rectangle(rectangleData, identifier);

            int groupIndex = canvas.GetGroupIndex(group);
            if (groupIndex > -1)
            {
                canvas.AddNewShapeToGroup(rectangle, groupIndex);
                Console.WriteLine("Dreptunghiul a fost adaugat cu succes in grup!");
            }
            else
            {
                Console.WriteLine("Dreptunghiul nu a fost adaugat in grup!");
            }

            Console.Read();
        }

        private void CreateNewGroup(object sender, object contextObject)
        {
            int identifier;
            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }
            Group group = new Group(identifier);
            canvas.AddNewGroup(group);
        }

        private void ListAllObjects(object sender, object contextObject)
        {
            ListShapes(canvas.GetAllShapes());
            ListAllGroups();
            Console.Read();
        }

        private void ListShapes(List<Shape> shapes)
        {
            foreach (var item in shapes)
            {
                Console.Write("{0} ->", item.Name());
                int first = 0;
                foreach (var data in item.Data())
                {
                    if (first != 0)
                    {
                        Console.Write(",");
                    }
                    Console.Write(" {0}={1}", data.Key, data.Value);
                    ++first;
                }
                Console.Write(", Identificator={0}, Arie={1}\n", item.Identifier(), item.ComputeArea());
            }
        }

        private void ListAllGroups()
        {
            foreach (var item in canvas.GetAllGroups())
            {
                Console.Write(" {0} -> Identificator={1}, ArieTotala={2}\n", item.Name(), item.Identifier(), item.ComputeArea());
                ListShapes(item.GetAllShapes());
            }
        }
    }
}
