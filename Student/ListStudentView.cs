using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class ListStudentView : View
    {
        private StudentsController controller;

        public ListStudentView(StudentsController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            foreach (var student in controller.GetAllStudents())
            {
                Console.WriteLine("Name = {0}, Surname = {1}, Group = {2}, Id = {3}", student.GetName(), student.GetSurname(), student.GetGroup(), student.GetID());
            }
            Console.ReadLine();

            View retView = null;
            return retView;
        }
    }
}
