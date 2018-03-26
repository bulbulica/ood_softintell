using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class DeleteStudentView : View
    {
        private StudentsController controller;

        public DeleteStudentView(StudentsController controller)
        {
            this.controller = controller;
        }

        public override View Execute()
        {
            int id;

            Console.WriteLine("Id of the student you want to delete : ");
            id = Int32.Parse(Console.ReadLine());

            View retView = controller.DeleteStudent(id);
            return retView;
        }
    }
}
