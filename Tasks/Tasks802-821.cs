using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;

namespace Tasks
{
    public class Tasks802_821
    {
        public int Task802(string text)
        {
            int maxCount = 0;
            int currentCount = 0;
            char previousLetter = 'a';
            foreach (var letter in text)
            {
                if (char.IsLetter(letter) && char.IsDigit(previousLetter))
                {
                    if (maxCount < currentCount)
                        maxCount = currentCount;
                    currentCount = 0;
                }
                if (char.IsDigit(letter))
                {
                    currentCount++;
                }
                previousLetter = letter;
            }

            return maxCount;
        }

        public bool Task803(string text)
        {
            foreach (var letter in text)
            {
                if (!(char.IsLetter(letter) || char.IsWhiteSpace(letter)))
                {
                    return true;
                }
            }

            return false;
        }

        public string Task804a(string text)
        {
            var index = 0;
            var builder = new StringBuilder(text);
            // Find index of first *
            foreach (var letter in text)
            {
                if (letter == '*')
                    break;
                index++;
            }
            if (index == text.Length)
                return text;
            for (int i = 0; i < index; i++)
            {
                if (char.IsLower(builder[i]))
                    builder[i] = char.ToUpper(builder[i]);
            }

            return builder.ToString();
        }

        public string Task804b(string text)
        {
            var index = 0;
            // Find index of first *
            foreach (var letter in text)
            {
                if (letter == '+')
                    break;
                index++;
            }
            if (index == text.Length)
                return text;

            var builder = new StringBuilder(text);
            for (int i = 0; i < index; i++)
            {
                if (char.IsDigit(builder[i]))
                    builder[i] = '-';
            }

            return builder.ToString();
        }

        public string Task805(string text)
        {
            var index = 0;
            char previous = '1';
            // Find first index where current char is not lower and previous is
            while (index < text.Length)
            {
                char current = text[index];
                if (!char.IsLower(current) && char.IsLower(previous))
                    break;
                previous = current;
                index++;
            }
            if (index == text.Length)
                return text;

            var builder = new StringBuilder(text);
            for (int i = index; i < text.Length; i++)
                builder[i] = '.';
            return builder.ToString();
        }

        // What does "идентификатор" means???
        public bool Task806a(string text)
        {
            foreach (var letter in text)
            {
                if (!char.IsLetterOrDigit(letter))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Task806b(string text)
        {
            // Check sign
            if (!(text[0] == '-' || text[0] == '+' || (char.IsDigit(text[0])&& text[0] != '0')))
            {
                return false;
            }

            for (int i = 1; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]))
                    return false;
            }

            return true;
        }

        // I don't know(
        public string[] Task807(char[,] matrix)
        {
            return null;
        }

        public Dictionary<string, int> Task808a(string text)
        {
            var builder = new StringBuilder();
            var dict = new Dictionary<string, int>();
            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    if (0 < builder.Length)
                    {
                        var str = builder.ToString();
                        if (!dict.ContainsKey(str))
                            dict[str] = 0;
                        dict[str]++;
                        builder.Clear();
                    }
                }
                else
                    builder.Append(letter);
            }

            // Crutch
            if (0 < builder.Length)
            {
                var str = builder.ToString();
                if (!dict.ContainsKey(str))
                    dict[str] = 0;
                dict[str]++;
                builder.Clear();

            }

            return dict;
        }

        public List<string> Task808b(string text)
        {
            var builder = new StringBuilder();
            var vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
            var words = new List<string>();
            int maxVowelCount = 0;
            int currentVowelCount = 0;
            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    if (0 < builder.Length)
                    {
                        if (maxVowelCount < currentVowelCount)
                        {
                            maxVowelCount = currentVowelCount;
                            words.Clear();
                            words.Add(builder.ToString());
                        }

                        if (maxVowelCount == currentVowelCount)
                        {
                            var str = builder.ToString();
                            bool contains = false;
                            foreach (var word in words)
                                if (word == str)
                                {
                                    contains = true;
                                    break;
                                }
                            if (!contains)
                                words.Add(str);

                        }
                    }

                    builder.Clear();
                    currentVowelCount = 0;
                }
                else
                {
                    builder.Append(letter);
                    foreach (var vowel in vowels)
                    {
                        if (letter == vowel)
                        {
                            currentVowelCount++;
                            break;
                        }
                    }
                }
            }

            if (0 < builder.Length)
            {
                if (maxVowelCount < currentVowelCount)
                {
                    maxVowelCount = currentVowelCount;
                    words.Clear();
                    words.Add(builder.ToString());
                }

                if (maxVowelCount == currentVowelCount)
                {
                    var str = builder.ToString();
                    bool contains = false;
                    foreach (var word in words)
                        if (word == str)
                        {
                            contains = true;
                            break;
                        }
                    if (!contains)
                        words.Add(str);

                }
            }
            return words;
        }

        private List<string> SplitText(string text)
        {
            var builder = new StringBuilder();
            var words = new List<string>();
            foreach (var letter in text)
            {
                if (letter == ' ')
                {
                    if (0 < builder.Length)
                    {
                        var str = builder.ToString();
                        words.Add(str);
                        builder.Clear();
                    }
                }
                else
                {
                    builder.Append(letter);
                }
            }

            if (0 < builder.Length)
            {
                words.Add(builder.ToString());
            }

            return words;
        }
        public List<string> Task808c(string text)
        {
            var maxProportion = 0.0;
            var words = SplitText(text);
            var total = new List<string>();
            foreach (var word in words)
            {
                // Count proportion
                var currentProportion = 0.0;
                foreach (var letter in word)
                {
                    if (letter == 'a' || letter == 'b')
                        currentProportion++;
                }
                currentProportion /= word.Length;

                // Differ current with maximum
                if (maxProportion < currentProportion)
                {
                    maxProportion = currentProportion;
                    total.Clear();
                    total.Add(word);
                }
                else if (Math.Abs(maxProportion - currentProportion) < 0.01)
                {
                    total.Add(word);
                }
            }

            return total;
        }

        public List<string> Task808d(string text)
        {
            var words = SplitText(text);
            var total = new List<string>();
            var builder = new StringBuilder();
            foreach (var word in words)
            {
                builder.Append(word);
                if (3 <= word.Length)
                {
                    var length = word.Length;
                    if (word[length - 3] == 'i' && word[length - 2] == 'n' && word[length - 1] == 'g')
                    {
                        builder.Remove(length - 3, 3);
                        builder.Append("ed");
                    }
                }
                total.Add(builder.ToString());
                builder.Clear();
            }

            return total;
        }

        public string Task809(int number)
        {
            var builder = new StringBuilder();
            var length = 1;
            var size = 1;
            while (number / (length *= 10) != 0)
            {
                size++;
            }

            int remainder = 1;
            for (int i = 0; i < size % 3; i++)
            {
                remainder *= 10;
            }

            if (remainder != 1)
            {
                // Add first digits
                builder.Append(number / (length / remainder));
                number %= (length /= remainder);
                if (length >= 1000)
                {
                    builder.Append(' ');
                }
            }

            while (0 < number && 1 < length)
            {
                builder.Append(number / (length / 1000));
                number %= length / 1000;
                length /= 1000;
                if (number != 0)
                    builder.Append(' ');
            }

            return builder.ToString();
        }

        private static string Task810(int n)
        {
            if (n == 1000)
                return "одна тысяча";
            var result = new StringBuilder();
            var numerals = new[] {"один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"};
            var tens = new string[9];
            var hundreads = new string[9];
            tens[0] = "десять";
            tens[3] = "сорок";
            tens[8] = "девяносто";
            for (int i = 1; i <= 2; i++)
            {
                tens[i] = numerals[i] + "дцать";
            }

            for (int i = 4; i <= 7; i++)
            {
                tens[i] = numerals[i] + "десять";
            }

            hundreads[0] = "сто";
            hundreads[1] = "двести";
            for (int i = 2; i <= 3; i++)
            {
                hundreads[i] = numerals[i] + "ста";
            }

            for (int i = 3; i <= 8; i++)
            {
                hundreads[i] = numerals[i] + "сот";
            }

            var number = new string[3][];
            number[0] = numerals;
            number[1] = tens;
            number[2] = hundreads;
            var startIndex = 0;
            while (n > 0)
            {
                if (n % 10 != 0)
                    result.Insert(0, number[startIndex][n % 10 - 1] + ' ');
                startIndex++;
                n /= 10;
            }

            return result.ToString();
        }


        public string Task811(int n)
        {
            var builder = new StringBuilder();
            var penny = n % 100;
            var rubles = n / 100;
            builder.Append(rubles)
                   .Append(" руб. ")
                   .Append(penny > 9
                               ? penny
                               : penny > 0
                                   ? "0" + penny
                                   : "00")
                   .Append(" коп.");

            return builder.ToString();
        }

        public bool Task812a(string text)
        {
            const string pattern = "one";
            for (int i = 0; i < text.Length - 2; i++)
            {
                if (text[i] == pattern[0] && text[i + 1] == pattern[1] && text[i + 2] == pattern[2])
                    return true;
            }

            return false;
        }

        public bool Task812b(string text)
        {
            throw new NotImplementedException();
        }
        
        
        private static List<string> MakeList(string text, Func<char, bool> foo)
        {
            var list = new List<string>();
            var index = 0;
            var len = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (foo(text[i]))
                {
                    len++;
                    if (i == text.Length - 1)
                    {
                        list.Add(text.Substring(index, len));
                    }
                }
                else
                {
                    if (len != 0)
                        list.Add(text.Substring(index, len));
                    len = 0;
                    index = i + 1;
                }
            }

            return list;
        }
        
        private bool Task812A(string text)
        {
            var group = "one";
            var wordsGroup = MakeList(text, char.IsLetter);
            foreach (var word in wordsGroup)
            {
                if (word.Length != group.Length)
                    continue;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] != group[i])
                        break;
                    if (i == group.Length - 1)
                        return true;
                }
            }

            return false;
        }
        
        private static bool Task812B(string text)
        {
            var wordsGroup = MakeList(text, char.IsLetter);
            var signsGroup = MakeList(text, IsSign);
            return wordsGroup.Count > signsGroup.Count;
        }

        private static bool IsSign(char e)
        {
            return e == '+' || e == '*' || e == '-';
        }

        private static string Task812C(string text)
        {
            var wordsGroup = MakeList(text, char.IsLetter);
            var startIndex = 0;
            while (!char.IsLetter(text[startIndex]))
            {
                startIndex++;
            }

            var lastIndex = startIndex + wordsGroup[0].Length;
            while (!char.IsLetter(text[lastIndex]))
            {
                lastIndex++;
            }

            var builder = new StringBuilder(text);
            for (int i = startIndex; i < lastIndex; i++)
            {
                if (builder[i] == '+')
                    builder[i] = '1';
                else if (builder[i] == '-')
                    builder[i] = '2';
                else if (builder[i] == '*')
                    builder[i] = '3';
            }

            return builder.ToString();
        }

        private static int Task812D(string text)
        {
            var result = 0;
            var wordsGroup = MakeList(text, char.IsLetter);
            if (wordsGroup.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < wordsGroup[i].Length; j++)
                    {
                        if (wordsGroup[i][j] == 'f')
                            result++;
                    }
                }
            }

            return result;
        }

        private static int Task812E(string text)
        {
            var wordsGroup = MakeList(text, char.IsLetter);
            var result = 0;
            foreach (var word in wordsGroup)
            {
                if (word[0] == word[word.Length - 1])
                    result++;
            }

            return result;
        }


        private static List<string> Task812F(string text)
        {
            var result = new List<string>();
            var wordsGroup = MakeList(text, char.IsLetter);
            foreach (var word in wordsGroup)
            {
                var count = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == 'a')
                        count++;
                }

                if (count >= 2)
                    result.Add(word);
            }

            return result;
        }

        private static string Task812G(string text)
        {
            string result = "";
            var numbersGroup = MakeList(text, char.IsNumber);
            var maxLen = 0;
            foreach (var number in numbersGroup)
            {
                if (number.Length > maxLen)
                {
                    maxLen = number.Length;
                    result = number;
                }
            }

            return result;
        }
        
        private static string Task813(string text)
        {
            if (!char.IsLetter(text[0]) || !char.IsLower(text[0]))
                return text;
            var index = 0;
            while (index != text.Length && char.IsLetter(text[index]))
            {
                index++;
            }

            if (index == text.Length || !char.IsDigit(text[index]))
                return text;
            var builder = new StringBuilder(text);
            while (index != text.Length && char.IsDigit(builder[index]))
            {
                builder[index] = '*';
                index++;
            }

            return builder.ToString();
        }
    }
}
