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

        private int ReadIdentifier()
        {
            int identifier = -1;
            while (true)
            {
                Console.WriteLine("Identificator: ");
                identifier = compute.ToInt(Console.ReadLine());
                if (!canvas.CheckExistingIdentifier(identifier))
                {
                    break;
                }
            }
            return identifier;
        }

        private Circle ReadCircle()
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

            identifier = ReadIdentifier();

            centerNumber = new Tuple<double, double>(firstCenter, secondCenter);
            Dictionary<String, object> circleData = new Dictionary<string, object>();

            circleData.Add(radius, radiusNumber);
            circleData.Add(center, centerNumber);

            return new Circle(circleData, identifier);
        }

        private void AddNewCircle(object sender, object contextObject)
        {
            Shape circle = ReadCircle();

            canvas.AddNewShape(circle);

            Console.WriteLine("Cercul a fost adaugat cu succes");
            Console.Read();
        }

        private void AddNewCircleToGroup(object sender, object contextObject)
        {
            Shape circle = ReadCircle();

            Console.WriteLine("Grup: ");
            int group = compute.ToInt(Console.ReadLine());

            AddToShapeToCanvasGroups(circle, group);
            Console.Read();
        }

        private Rectangle ReadRectangle()
        {
            String latura1 = "Latura1";
            String latura2 = "Latura2";
            double laturaBig, laturaSmall;
            int identifier;

            Console.WriteLine(latura1 + ": ");
            laturaBig = compute.ToDouble(Console.ReadLine());

            Console.WriteLine(latura2 + ": ");
            laturaSmall = compute.ToDouble(Console.ReadLine());

            identifier = ReadIdentifier();

            Dictionary<String, object> rectangleData = new Dictionary<string, object>();

            rectangleData.Add(latura1, laturaBig);
            rectangleData.Add(latura2, laturaSmall);

            return new Rectangle(rectangleData, identifier);
        }

        private void AddNewRectangle(object sender, object contextObject)
        {
            Shape rectangle = ReadRectangle();

            canvas.AddNewShape(rectangle);

            Console.WriteLine("Dreptunghiul a fost adaugat cu succes!");
            Console.Read();
        }

        private void AddNewRectangleToGroup(object sender, object contextObject)
        {
            Shape rectangle = ReadRectangle();

            Console.WriteLine("Grup: ");
            int group = compute.ToInt(Console.ReadLine());

            AddToShapeToCanvasGroups(rectangle, group);
            Console.Read();
        }

        private void AddToShapeToCanvasGroups(Shape shape, int identifier)
        {
            int groupIndex = canvas.GetGroupIndex(identifier);
            if (groupIndex > -1)
            {
                canvas.AddNewShapeToGroup(shape, groupIndex);
                Console.WriteLine("Forma a fost adaugata cu succes in grup!");
            }
            else
            {
                Console.WriteLine("Forma nu a fost adaugata in grup!");
            }
        }

        private void CreateNewGroup(object sender, object contextObject)
        {
            int identifier;
            identifier = ReadIdentifier();

            Group group = new Group(identifier);
            canvas.AddNewGroup(group);
            Console.WriteLine("Grupul a fost adaugat cu succes!");
            Console.Read();
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
