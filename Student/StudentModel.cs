using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class StudentModel
    {
        private String name;
        private String surname;
        private int id;
        private String group;

        public StudentModel(String name, String surname, String group, int id)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
            this.id = id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }

        public string GetGroup()
        {
            return group;
        }

        public int GetID()
        {
            return id;
        }

        public void ModifyStudent(StudentModel student)
        {
            this.name = student.GetName();
            this.surname = student.GetSurname();
            this.group = student.GetGroup();
            //this.id = student.GetID();
        }
    }
}
