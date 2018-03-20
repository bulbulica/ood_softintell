using OOPBasicsShared;
using System;
using System.Collections.Generic;
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
        ConsoleMenu firstMenu = new ConsoleMenu();
        ConsoleMenu secondMenu = new ConsoleMenu();

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

            firstMenu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Encode", ActionToExecute = new MenuItemAction(DoEncoders) });
            firstMenu.AddItem(new MenuItem { ShortcutChar = '2', Text = "Decode", ActionToExecute = new MenuItemAction(DoDecoders) });

            
            //consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = encoderPlugin.GetName(), ContextObject = encoderPlugin, ItemAction = new MenuItemAction(DecodeAction) });
        }

        public void RunApp()
        {
            firstMenu.Run();
        }

        private void RunSecondMenu()
        {
            secondMenu.Run();
        }

        private void DoEncoders(object sender, object contextObject)
        {
            RunSecondMenu();

            Console.WriteLine("\nAll the existing encoders:");

            for (var i = 1; i <= existingEncoderPlugins.Count; ++i)
            {
                secondMenu.AddItem(new MenuItem { ShortcutChar = (char)i, Text = existingEncoderPlugins[i].GetName(), ActionToExecute = new MenuItemAction(UseEncoder) });
                //Console.WriteLine("{0}.{1}", i + 1, existingEncoderPlugins[i].GetName());
            }
        }

        private void UseEncoder(object sender, object contextObject)
        {

        }

        private void DoDecoders(object sender, object contextObject)
        {
            Console.WriteLine("\nAll the existing decoders:");

            for (var i = 0; i < existingDecoderPlugins.Count; ++i)
            {
                Console.WriteLine("{0}.{1}", i + 1, existingDecoderPlugins[i].GetName());
            }
            Console.ReadKey();
        }
    }
}
