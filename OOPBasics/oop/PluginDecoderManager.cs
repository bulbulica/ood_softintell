using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OOPBasics
{
    class PluginDecoderManager
    {
        private String pluginsDirectory;
        private List<IDecoderPlugin> plugins;

        public PluginDecoderManager(String pluginsDirectory)
        {
            this.pluginsDirectory = pluginsDirectory;
            plugins = new List<IDecoderPlugin>();
        }

        public void LoadPlugins()
        {
            var filesList = GetPluginFiles();
            foreach (var file in filesList)
            {
                var dllFile = Assembly.LoadFile(file);
                var exportedTypes = dllFile.GetExportedTypes();
                var pluginIPlugin = typeof(IDecoderPlugin);
                foreach (var currentType in exportedTypes)
                {
                    if (pluginIPlugin.IsAssignableFrom(currentType))
                    {
                        IDecoderPlugin currentPlugin = (IDecoderPlugin)Activator.CreateInstance(currentType);
                        plugins.Add(currentPlugin);
                    }
                }
            }
        }

        private IEnumerable<String> GetPluginFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(pluginsDirectory);
            List<String> files = new List<String>();

            foreach (var fileName in directory.EnumerateFiles())
            {
                files.Add(fileName.FullName);
            }

            return files;
        }

        public List<IDecoderPlugin> GetPlugins()
        {
            return plugins;
        }
    }
}
