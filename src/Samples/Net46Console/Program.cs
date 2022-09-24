using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using CommonComponents;
using EnglishPlugin;
using GermanPlugin;

namespace Net46Console
{
    class Program
    {
        private static ContainerBuilder builder;

        static IEnumerable<Assembly> Assemblies
        {
            get
            {
                yield return typeof(CommonModule).Assembly;
                // instead of directly linking against the plugin assemblies you could also load them from the current directory
                yield return typeof(GermanModule).Assembly;
                yield return typeof(EnglishModule).Assembly;
            }
        }

        public static List<Assembly> loadAssemnbliesDynamically()
        {
            var path = "C:\\rust server\\RustDedicated_Data\\Managed";
            path = Environment.CurrentDirectory;
            var coreFiles = Directory.GetFiles(path, "*.dll");
            var assemblies = new List<Assembly>();
            var coreExtension = new List<Type>();
            // Load each assembly into domain
            foreach (var file in coreFiles)
            {
                var lAssembly = Assembly.LoadFile(file);
                var assembly = Assembly.Load(lAssembly.FullName);

                var iscan = assembly.GetExportedTypes().Where(a =>
                    a.IsClass && a.Namespace != null && typeof(IBaseStrategy).IsAssignableFrom(a));

                if (iscan.Any())
                {
                    assemblies.Add(assembly);
                }
                else
                {
                    continue;
                    
                }

               // builder.RegisterAssemblyTypes(assembly).Where(t => t.IsAssignableTo<IBaseStrategy>()).SingleInstance();
                //builder.RegisterAssemblyTypes(assembly).Where(t => t.IsAssignableTo<IBaseStrategy>()).SingleInstance();

                // Add all IVmeExtension types
                coreExtension.AddRange(assembly.GetExportedTypes()
                    .Where(a => a.IsClass &&
                               
                                a.Namespace != null &&
                                
                                typeof(IBaseStrategy).IsAssignableFrom(a)));
            }
            return assemblies;

        }
        static void Main()
        {
            var log = (Action<string>) Console.WriteLine;

            log("Loading and using all plugins:");

             builder = new ContainerBuilder();

            var assemb = loadAssemnbliesDynamically();


            //builder.RegisterAssemblyModules(Assemblies.ToArray());
            builder.RegisterAssemblyModules(assemb.ToArray());
            var container = builder.Build();

            var allHelloWorlds = container.Resolve<IEnumerable<IBaseStrategy>>();
            foreach (var helloWorld in allHelloWorlds)
            {
                 
                log($"{helloWorld.Start()} => {helloWorld.StrategyName}");
            }

            log("Press <Enter> to exit...");
            Console.ReadLine();
        }
    }
}