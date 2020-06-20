using System;
using LibGit2SharpTestLib;

namespace LibGit2SharpTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Test().Run();
            Console.WriteLine($"Found: {result}");
        }
    }
}
