using System;
using System.Threading;

namespace WorkWuthString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input text");
            string input = Console.ReadLine();
            Console.Clear();
            GetPunctuationNum(input);
            Console.WriteLine();
            SplitOnSentences(input);
            string[] words = GetArrayWords(input);
            GetUnicWords(words);
            Console.WriteLine();
            string LongestWord = GetTheLongestWord(words);
            Console.WriteLine("The longest world is: " + LongestWord);
            Console.WriteLine();
            Perversion(LongestWord);
        }
        static void GetPunctuationNum(string input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsPunctuation(input[i])) result++;
            }
            Console.WriteLine("Number of punctuation marks is: " + result);
        }
        static void SplitOnSentences(string input)
        {
            Console.WriteLine("Sentences in the text:");
            string[] sentences = input.Split(new char[] { '.' });
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
                Console.WriteLine();
                Thread.Sleep(20);
            }
        }
        static string[] GetArrayWords(string input)
        {
            string[] words = input.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!char.IsLetterOrDigit(words[i][j])) words[i] = words[i].Remove(j);
                }
            }
            return words;
        }
        static void GetUnicWords(string[] input)
        {
            Console.Write("Unic words: ");
            for (int i = 0; i < input.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i] == input[j]) count++;
                }
                if (count == 1) Console.Write(input[i] + ", ");
            }
            Console.WriteLine();
        }
        static string GetTheLongestWord(string[] input)
        {
            string longest = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > longest.Length) longest = input[i];
            }
            return longest;
        }
        static void Perversion(string input)
        {
            Console.Write("Changes in the longest word");
            if (input.Length % 2 == 0)
            {
                for (int i = (input.Length / 2); i < input.Length; i++)
                {
                    Console.Write(input[i]);
                }
            }
            else
            {
                Console.WriteLine(input.Replace(input[(input.Length / 2)], '*'));
            }
        }
    }
}
