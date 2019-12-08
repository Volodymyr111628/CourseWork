using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReflectionHomework.Common
{
    public static class DynamicClassInstanceLoader
    {
        public static List<T> LoadInstances<T>(string assemblyPath)
        {
            var rules = new List<T>();

            if(!Directory.Exists(assemblyPath))
            {
                throw new DirectoryNotFoundException();
            }

            IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
                assemblyPath, "*.dll", SearchOption.AllDirectories);

            foreach (string assemblyFile in assemblyFiles)
            {
                Assembly assembly = Assembly.LoadFrom(assemblyFile);
                
                foreach (Type type in assembly.ExportedTypes)
                {
                    if(type.IsClass&&typeof(T).IsAssignableFrom(type))
                    {
                        T rule = (T)Activator.CreateInstance(type);

                        rules.Add(rule);
                    }
                }
            }

            return rules;
        }
    }
}
