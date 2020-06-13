using System;

namespace GitInfoTest
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine(ThisAssembly.Git.BaseVersion.Major);
        }
    }
}
