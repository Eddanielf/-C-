using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utilities
{
    public static class Message
    {

        private static string[] separators = { ",", ".", "!", "?", ";", ":", " " };

        public static void PrintWords(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                string str = words[i];

                if (words[i].Length >= 3 && words[i][0] == (words[i][words[i].Length - 1]))
                {
                    Console.WriteLine(words[i]);
                }
            }
        }

        public static void PrintWords(string message, int n)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                string str = words[i];

                if (words[i].Length <= n)
                {
                    Console.Write(words[i] + " ");
                }
            }
        }

        public static string RemoveWords(string message, string userWord)
        {
            if (string.IsNullOrEmpty(message))
                return null;
            StringBuilder stringBuilder = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word != userWord)
                    stringBuilder.Append($"{word} ");
            }

            return stringBuilder.ToString();


        }

        public static string GetStringFromWords(string message, int minWordLenght)
        {
            if (string.IsNullOrEmpty(message))
                return null;
            StringBuilder stringBuilder = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length >= minWordLenght)
                    stringBuilder.Append($"{word} ");
            }

            return stringBuilder.ToString();

        }

        public static string MaxWord(string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;
            
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string maxWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > maxWord.Length)
                {
                    maxWord = words[i];
                }
            }

            return maxWord;
        }

        public static string MinWord(string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;
            
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string minWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < minWord.Length)
                {
                    minWord = words[i];
                }
            }

            return minWord;
        }

        public static string maxWords(string message)
        {
            if (string.IsNullOrEmpty(message))
            return null;
            StringBuilder str = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                str.Append($"{word} ");
            }

            int n = 0;
            do
            {   
                string maxWord = Message.MaxWord(str.ToString());
                str1.Append(maxWord + " ");
                str.Replace(maxWord, " ");
                n++;
            }
            while (n < 3);

            return str1.ToString();

        }

        public static bool CompareStrings(string str1, string str2)
        {
            
            bool f = str1.Select(Char.ToLower).OrderBy(x => x).SequenceEqual(str2.Select(Char.ToLower).OrderBy(x => x));
            return f;
        }
    }
}
