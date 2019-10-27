namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var files = GetAllFiles(Environment.CurrentDirectory); //recursion implemented
            var catalogue = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                var name = file.Name;
                var extension = file.Extension;
                var size = file.Length;

                if (!catalogue.ContainsKey(extension))
                {
                    catalogue[extension] = new Dictionary<string, long>();
                }

                //if run in a folder with files with same name in different subfolders, this throws an error
                catalogue[extension].Add(name, size); 
            }

            var sortedCatalogues = catalogue.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            //this is how you can always specify to find the Desktop on each machine
            var fileName = "report.txt";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName); 

            using (var sw = new StreamWriter(path))
            {
                foreach (var group in sortedCatalogues)
                {
                    sw.WriteLine(group.Key);

                    foreach (var kvp in group.Value.OrderBy(x => x.Value))
                    {
                        sw.WriteLine($"--{kvp.Key} - {(kvp.Value / 1000.0):F3}kb");
                    }
                }
            }
        }

        private static List<FileInfo> GetAllFiles(string path)
        {
            var rootDirectory = new DirectoryInfo(path);

            var allFiles = new List<FileInfo>();

            var files = rootDirectory.GetFiles();
            allFiles.AddRange(files);

            var subDirectories = rootDirectory.GetDirectories();

            foreach (DirectoryInfo directory in subDirectories)
            {
                var subFiles = GetAllFiles(directory.FullName);
                allFiles.AddRange(subFiles);
            }

            return allFiles;
        }
    }
}
