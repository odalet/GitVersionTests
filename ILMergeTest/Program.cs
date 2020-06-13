using System;
using System.Reflection;

namespace ILMergeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test(typeof(ClassLibrary1.Class1).Assembly);
            Test(typeof(ClassLibrary2.Class1).Assembly);
            Test(typeof(ClassLibrary3.Class1).Assembly);
        }

        private static void Test(Assembly assembly)
        {
            Console.WriteLine("------------------------------------------------------------------------");
            var assemblyName = assembly.GetName().Name;
            Console.WriteLine($"Testing {assemblyName}");
            Console.WriteLine("All Fields:");
            ////var gitVersionInformationType = assembly.GetType(assemblyName + ".GitVersionInformation");
            var gitVersionInformationType = assembly.GetType("GitVersionInformation");
            var fields = gitVersionInformationType.GetFields();
            var properties = gitVersionInformationType.GetProperties();
            foreach (var field in fields)
                Console.WriteLine(string.Format("{0}: {1}", field.Name, field.GetValue(null)));
            foreach (var property in properties)
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.GetGetMethod(true).Invoke(null, null)));

            Console.WriteLine();
            Console.WriteLine("Specific Field:");
            var versionField = gitVersionInformationType.GetField("Major");
            if (versionField != null)
                Console.WriteLine(versionField.GetValue(null));
            else
            {
                var versionProperty = gitVersionInformationType.GetProperty("Major");
                if (versionProperty != null)
                    Console.WriteLine(versionProperty.GetGetMethod(true).Invoke(null, null));
            }
        }
    }
}
