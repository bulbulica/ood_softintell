using System;
using System.Collections.Generic;

namespace test
{
    class Student
    {
        public string Name { get; set; }
    }
    class Program
    {
        
        static void testString(ref String testString)
        {
            testString = testString + "a";
        }

        static void testString(String testString)
        {
            testString = testString + "a";
        }

        static void testInt(ref Int32 testNum)
        {
            testNum++;
        }

        static void testInt(Int32 testNum)
        {
            testNum++;
        }

        static void AddToList(List<Int32> list)
        {
            list.Add(3);
        }

        static void ChangeStudent(Student std)
        {
            std.Name = "TEST";
            std = new Student { Name="Antother TEST"};
        }

        static void Main(string[] args)
        {
            String nameString = "abc";
            Int32 nameNum = 2;
            List<Int32> testList = new List<Int32>();
            Student std = new Student { Name = "ABC"};
            testString(nameString);
            testString(ref nameString);
            testInt(ref nameNum);
            testInt(nameNum);
            AddToList(testList);
            ChangeStudent(std);
            Console.WriteLine(nameString);
            Console.WriteLine(nameNum);
            Console.WriteLine(std.Name);
            Console.WriteLine(testList[0]);
        }
    }
}
