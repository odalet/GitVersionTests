using System;

namespace GitInfoTest
{
    class Program
    {
        static void Main(string[] args) 
        {
            var version = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";
            Console.WriteLine(version);
        }
    }
}
