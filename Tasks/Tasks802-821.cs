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
    }
}