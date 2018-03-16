using System;
using System.IO;

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
            Random rand = new Random();

            EnigmaEncoder enigmaEncoder = new EnigmaEncoder(100, 500, rand.Next(0, 127));

            CesarEncoder cesarEncoder = new CesarEncoder();

            IEncoder selectedAlgorithm = cesarEncoder;

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
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
