using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OOPBasics
{
    public class PluginEncoderManager
    {
        private String pluginsDirectory;
        private List<IEncoderPlugin> plugins;

        public PluginEncoderManager(String pluginsDirectory)
        {
            this.pluginsDirectory = pluginsDirectory;
            plugins = new List<IEncoderPlugin>();
        }

        public void LoadPlugins()
        {
            var filesList = GetPluginFiles();
            foreach (var file in filesList)
            {
                var dllFile = Assembly.LoadFile(file);
                var exportedTypes = dllFile.GetExportedTypes();
                var pluginIPlugin = typeof(IEncoderPlugin);
                foreach (var currentType in exportedTypes)
                {
                    if (pluginIPlugin.IsAssignableFrom(currentType))
                    {
                        IEncoderPlugin currentPlugin = (IEncoderPlugin)Activator.CreateInstance(currentType);
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

        public List<IEncoderPlugin> GetPlugins()
        {
            return plugins;
        }
    }
}
