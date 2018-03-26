using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class StudentsController
    {
        private List<StudentModel> students;

        public StudentsController()
        {
            students = new List<StudentModel>();
        }

        public StudentsController(List<StudentModel> students)
        {
            this.students = students;
        }

        public View Index()
        {
            return new MainView(this);
        }

        public View GetAddStudentView()
        {
            AddStudentView addStudentView = new AddStudentView(this);
            return addStudentView;
        }

        public View AddStudent(StudentModel student)
        {
            students.Add(student);
            return null;
        }

        public View GetListStudentView()
        {
            ListStudentView listStudentView = new ListStudentView(this);
            return listStudentView;
        }

        public List<StudentModel> GetAllStudents()
        {
            return students;
        }

        public View GetDeleteStudentView()
        {
            DeleteStudentView deleteStudentView = new DeleteStudentView(this);
            return deleteStudentView;
        }

        public View DeleteStudent(int id)
        {
            for (int iterator = 0; iterator < students.Count; ++iterator)
            {
                if (getStudentId(students[iterator]) == id)
                {
                    students.RemoveAt(iterator);
                }
            }
            return null;
        }

        public View GetModifyStudentView()
        {
            ModifyStudentView modifyStudentView = new ModifyStudentView(this);
            return modifyStudentView;
        }

        public View ModifyStudent(int id, StudentModel newStudent)
        {
            foreach (var student in students)
            {
                if (getStudentId(student) == id)
                {
                    student.ModifyStudent(newStudent);
                }
            }
            return null;
        }

        private int getStudentId(StudentModel student)
        {
            return student.GetID();
        }
    }
}
