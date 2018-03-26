using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentModel student = new StudentModel("nume", "preume", "group", 1);
            List<StudentModel> students = new List<StudentModel>();

            students.Add(student);

            StudentsController controller = new StudentsController(students);

            MainView mainView = new MainView(controller);

            mainView.Execute();
        }
    }
}
