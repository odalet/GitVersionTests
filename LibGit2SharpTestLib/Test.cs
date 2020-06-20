using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace LibGit2SharpTestLib
{
    public class Test
    {
        public string Run()
        {
            var dotgit = GetDotgitDirectory();
            if (dotgit == null) return null;

            var result = Repository.Discover(dotgit);
            return result;
        }

        private string GetDotgitDirectory()
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            //var directory = new DirectoryInfo(@"C:\Users\odalet\AppData\Local\Temp\TestRepositories\0c7af7b1-6f7f-4854-87e0-2a3ed9a03059");
            while (true)
            {
                if (directory == null)
                    return null;

                if (directory.EnumerateDirectories(".git", SearchOption.TopDirectoryOnly).Any())
                    return directory.ToString();

                directory = directory.Parent;
            }
        }
    }
}
