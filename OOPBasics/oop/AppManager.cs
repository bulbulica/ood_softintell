using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPBasics
{
    public class AppManager
    {
        private PluginsManager<IEncoderPlugin> encoderPlugins;
        private PluginsManager<IDecoderPlugin> decoderPlugins;
        private List<IEncoderPlugin> existingEncoderPlugins;
        private List<IDecoderPlugin> existingDecoderPlugins;
        private String dllPath = @"D:\OOPBasics";
        ConsoleMenu menu = new ConsoleMenu();

        public AppManager()
        {
            encoderPlugins = new PluginsManager<IEncoderPlugin>(dllPath);
            decoderPlugins = new PluginsManager<IDecoderPlugin>(dllPath);
        }

        public void Initialize()
        {
            encoderPlugins.LoadPlugins();
            decoderPlugins.LoadPlugins();
            existingEncoderPlugins = encoderPlugins.GetPlugins();
            existingDecoderPlugins = decoderPlugins.GetPlugins();

            char i = '1';

            foreach (var existingEncoderPlugin in encoderPlugins.GetPlugins())
            {
                menu.AddItem(new MenuItem { ShortcutChar = i, Text = existingEncoderPlugin.GetName() + " encoder", ContextObject = existingEncoderPlugin, ActionToExecute = new MenuItemAction(UseEncoder) });
                ++i;
            }

            foreach (var existingDecoderPlugin in decoderPlugins.GetPlugins())
            {
                menu.AddItem(new MenuItem { ShortcutChar = i, Text = existingDecoderPlugin.GetName() + " decoder", ContextObject = existingDecoderPlugin, ActionToExecute = new MenuItemAction(UseDecoder) });
                ++i;
            }
        }

        public void RunApp()
        {
            menu.Run();
        }

        private void UseEncoder(object sender, object contextObject)
        {
            IEncoderPlugin encoderPlugin = (IEncoderPlugin)contextObject;
            HandlePluginEncoderParameters(encoderPlugin);
            IEncoder selectedAlgorithm = encoderPlugin.GetEncoder();

            TextEncoder textEncoder = new TextEncoder(selectedAlgorithm);

            TextReader textReader = null;

            BinaryWriter binaryWriter = null;

            try
            {
                textReader = GetInputTextReader();

                StreamEncoder streamEncoder = new StreamEncoder(textReader, textEncoder);

                binaryWriter = GetOutputBinaryWriter();

                streamEncoder.Encode(binaryWriter);

                textReader.Close();
                binaryWriter.Close();

                Console.WriteLine("\nFile modified. Press any key to continue.");
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
                if (textReader != null)
                {
                    textReader.Close();
                }
                if (binaryWriter != null)
                {
                    binaryWriter.Close();
                }
            }
            Console.ReadLine();
        }

        private void UseDecoder(object sender, object contextObject)
        {
            IDecoderPlugin decoderPlugin = (IDecoderPlugin)contextObject;
            HandlePluginDecoderParameters(decoderPlugin);
            IDecoder selectedAlgorithm = decoderPlugin.GetDecoder();

            TextDecoder textDecoder = new TextDecoder(selectedAlgorithm);

            BinaryReader binaryReader = null;

            TextWriter textWriter = null;

            try
            {
                binaryReader = GetInputBinaryReader();

                StreamDecoder streamEncoder = new StreamDecoder(binaryReader, textDecoder);

                textWriter = GetOutputTextWriter();

                streamEncoder.Decode(textWriter);

                Console.WriteLine("File modified. Press any key to continue.");
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
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                if (textWriter != null)
                {
                    textWriter.Close();
                }
            }
            Console.ReadLine();
        }

        private void HandlePluginEncoderParameters(IEncoderPlugin encoderPlugin)
        {
        }

        private void HandlePluginDecoderParameters(IDecoderPlugin decoderPlugin)
        {
        }

        private TextReader GetInputTextReader()
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));
            return reader;
        }

        private BinaryReader GetInputBinaryReader()
        {
            var reader = new BinaryReader(File.OpenRead("encoded.bin"));
            return reader;
        }

        private BinaryWriter GetOutputBinaryWriter()
        {
            var writer = new BinaryWriter(File.OpenWrite("decoded.bin"));
            return writer;
        }

        private TextWriter GetOutputTextWriter()
        {
            var writer = new StreamWriter(File.OpenWrite("output.txt"));
            return writer;
        }
    }
}
