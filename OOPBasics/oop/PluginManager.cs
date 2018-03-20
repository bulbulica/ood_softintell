using OOPBasicsShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OOPBasics
{
    public class PluginsManager<T> 
    {
        private String pluginsDirectory;
        private List<T> plugins;

        public PluginsManager(String pluginsDirectory)
        {
            this.pluginsDirectory = pluginsDirectory;
            plugins = new List<T>();
        }

        public void LoadPlugins()
        {
            var filesList = GetPluginFiles();
            foreach (var file in filesList)
            {
                var dllFile = Assembly.LoadFile(file);
                var exportedTypes = dllFile.GetExportedTypes();
                var pluginIPlugin = typeof(T);
                foreach (var currentType in exportedTypes)
                {
                    if (pluginIPlugin.IsAssignableFrom(currentType))
                    {
                        T currentPlugin = (T)Activator.CreateInstance(currentType);
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

        public List<T> GetPlugins()
        {
            return plugins;
        }
    }
}
