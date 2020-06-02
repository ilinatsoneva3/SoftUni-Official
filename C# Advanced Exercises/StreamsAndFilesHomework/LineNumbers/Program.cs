namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = File.ReadLines("text.txt").ToList();
            List<string> output = new List<string>();

            for (int i = 1; i <= lines.Count(); i++)
            {
                var currentLine = lines[i - 1];
                var letters = 0;
                var punctuation = 0;

                for (int symbol = 0; symbol < currentLine.Length; symbol++)
                {
                    char currentChar = currentLine[symbol];

                    if (char.IsLetter(currentChar))
                    {
                        letters++;
                    }
                    else if (char.IsWhiteSpace(currentChar))
                    {
                        continue;
                    }
                    else
                    {
                        punctuation++;
                    }
                }

                var modifiedLine = $"Line {i}: {currentLine} ({letters})({punctuation})";
                output.Add(modifiedLine);
            }

            //exports it on Desktop
            var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt");
            File.WriteAllLines(outputPath, output);

        }
    }
}
