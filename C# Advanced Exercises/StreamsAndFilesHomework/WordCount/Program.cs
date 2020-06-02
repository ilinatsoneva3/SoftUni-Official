namespace WordCount
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var keyWords = File.ReadAllLines("words.txt").ToList();
            var wordDictionary = new Dictionary<string, int>();

            for (int i = 0; i < keyWords.Count; i++)
            {
                wordDictionary.Add(keyWords[i], 0);
            }

            var text = File.ReadAllLines("text.txt").ToList();

            for (int line = 0; line < text.Count; line++)
            {
                var currentLine = text[line].Split(new char[] { ' ', ',', '-', '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in currentLine)
                {
                    if (wordDictionary.ContainsKey(word.ToLower()))
                    {
                        wordDictionary[word.ToLower()]++;
                    }
                }
            }

            var actualResultOutput = new List<string>();

            foreach (var kvp in wordDictionary)
            {
                var thisLine = $"{kvp.Key} - {kvp.Value}";
                actualResultOutput.Add(thisLine);
            }

            File.WriteAllLines("actualResult.txt", actualResultOutput);

            var expectedResultOutput = new List<string>();

            foreach (var kvp in wordDictionary.OrderByDescending(x => x.Value))
            {
                var thisLine = $"{kvp.Key} - {kvp.Value}";
                expectedResultOutput.Add(thisLine);
            }

            File.WriteAllLines("expectedResult.txt", expectedResultOutput);
        }
    }
}
