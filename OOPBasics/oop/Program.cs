using OOPBasics;
using OOPBasicsShared;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace oop
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
            PluginEncoderManager pluginEncoderManager = new PluginEncoderManager(@"D:\OOPBasics");
            pluginEncoderManager.LoadPlugins();
            List<IEncoderPlugin> encoderPlugins = pluginEncoderManager.GetPlugins();

            PluginDecoderManager pluginDecoderManager = new PluginDecoderManager(@"D:\OOPBasics");
            pluginDecoderManager.LoadPlugins();
            List<IDecoderPlugin> decoderPlugins = pluginDecoderManager.GetPlugins();

            System.Console.WriteLine("Encoders :");
            for (var i = 0; i < encoderPlugins.Count; ++i)
            {
                System.Console.WriteLine("{0}.{1}", i, encoderPlugins[i].GetName());
            }

            System.Console.WriteLine("\nDecoders :");
            for (var i = 0; i < decoderPlugins.Count; ++i)
            {
                System.Console.WriteLine("{0}.{1}", i, decoderPlugins[i].GetName());
            }

            System.Console.WriteLine("\nAlgorithm choice to encode: {0}\n", args[0]);

            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return;
            }

            int encoderArgument = Int32.Parse(args[0]);

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
            }
        }
    }
}
