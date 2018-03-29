using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        private static TextWriter GetOutputTextWriter()
        {
            var writer = new StreamWriter(File.OpenWrite("logger.txt"));
            return writer;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = null;
            try
            {
                Logger logger = Logger.Instance;

                textWriter = GetOutputTextWriter();

                logger.LogInfo(textWriter, "1 + 1 = 2");

                logger.LogWarning(textWriter, "1 + 1 = 3");

                logger.LogError(textWriter, "1 / 0 = ?");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("WARNING: File is not available. Error Message: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(String.Format("Output Exception ocurred: '{0}'", e.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine("General Exception ocurred. Error Message: " + e.Message);
            }
            finally
            {
                if (textWriter != null)
                {
                    textWriter.Close();
                }
            }
            /*
            StudentModel student = new StudentModel("nume", "preume", "group", 1);
            List<StudentModel> students = new List<StudentModel>();

            students.Add(student);

            StudentsController controller = new StudentsController(students);

            MainView mainView = new MainView(controller);

            mainView.Execute();
            */
        }
    }
}
