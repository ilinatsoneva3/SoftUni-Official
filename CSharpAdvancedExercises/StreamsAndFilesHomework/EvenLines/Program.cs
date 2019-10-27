namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("text.txt"))
            {
                var counterLines = 0;
                var elementsToReplace = new List<string> { "-", ",", ".", "!", "?" };

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (counterLines % 2 == 0)
                    {
                        var stackOfWords = new Stack<string>(line.Split());

                        while (stackOfWords.Any())
                        {
                            var currentWord = stackOfWords.Pop();
                            StringBuilder word = new StringBuilder();
                            word.Append(currentWord);

                            for (int i = 0; i < elementsToReplace.Count; i++)
                            {
                                if (currentWord.Contains(elementsToReplace[i]))
                                {
                                    word.Replace(elementsToReplace[i], "@");
                                }
                            }

                            Console.Write(word + " ");
                        }

                        Console.WriteLine();
                    }

                    counterLines++;
                }
            }
        }
    }
}
