using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class AddStudentView : View
    {
        private StudentsController controller;

        public AddStudentView(StudentsController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            String name, surname, group;
            int id;

            Console.WriteLine("Add a new student:\nName : ");
            name = Console.ReadLine();

            Console.WriteLine("Surname : ");
            surname = Console.ReadLine();

            Console.WriteLine("Group : ");
            group = Console.ReadLine();

            Console.WriteLine("Id : ");
            id = Int32.Parse(Console.ReadLine());

            StudentModel student = new StudentModel(name, surname, group, id);

            View retView = controller.AddStudent(student);

            Console.WriteLine("Student succcesfully added!");
            Console.ReadLine();

            return retView;
        }
    }
}
