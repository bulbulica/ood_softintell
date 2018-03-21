using OOPBasics;
using OOPBasicsShared;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace OOPBasics
{
    class Program
    {
        static TextReader GetInputTextReader()
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));
            return reader;
        }

        static BinaryWriter GetOutputBinaryWriter()
        {
            var writer = new BinaryWriter(File.OpenWrite("encoded.txt"));
            return writer;
        }

        static void Main(string[] args)
        {
            AppManager app = new AppManager();
            app.Initialize();
            app.RunApp();
            /* 
            IEnumerable<String> arguments = encoderPlugins[encoderArgument].GetRequiredArguments();
            IDictionary<String, String> parameters = new Dictionary<String, String>();

            if (encoderArgument > encoderPlugins.Count || encoderArgument < 0)
            {
                System.Console.WriteLine("Wrong number");
                return;
            }
            if (encoderArgument == 1)
            {
                var argsValue = 1;
                foreach (var argument in arguments)
                {
                    System.Console.WriteLine("{0} = {1}", argument, args[argsValue]);
                    parameters.Add(argument, args[argsValue++]);
                }

                encoderPlugins[encoderArgument].SetArguments(parameters);
            }

            IEncoder selectedAlgorithm = encoderPlugins[encoderArgument].GetEncoder();

            TextEncoder textEncoder = new TextEncoder(selectedAlgorithm);

            TextReader reader = null;

            BinaryWriter writer = null; 

            try
            {
                reader = GetInputTextReader();
                writer = GetOutputBinaryWriter();

                StreamEncoder streamEncoder = new StreamEncoder(reader, textEncoder);

                streamEncoder.Encode(writer);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("WARNING: File is not available. Error Message: " + e.Message);
            }            
            catch (IOException e)
            {
                Console.WriteLine(String.Format("Input/Output Exception ocurred: '{0}'", e.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine("General Exception ocurred. Error Message: " + e.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }*/
        }
    }
}
