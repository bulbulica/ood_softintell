using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class ModifyStudentView : View
    {
        private StudentsController controller;

        public ModifyStudentView(StudentsController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            int id;
            String name, surname, group;

            Console.WriteLine("Id of the student you want to modify : ");
            id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("New name : ");
            name = Console.ReadLine();

            Console.WriteLine("New surname : ");
            surname = Console.ReadLine();

            Console.WriteLine("New group : ");
            group = Console.ReadLine();

            StudentModel student = new StudentModel(name, surname, group, id);

            View retView = controller.ModifyStudent(id, student);
            return retView;
        }
    }
}
