using System.Text.RegularExpressions;

namespace dllText
{
    public class Class
    {
        public static string TransformTextCase(string text, string mode)
        {
            switch (mode.ToLower())
            {
                case "lower":
                    return text.ToLower();
                case "upper":
                    return text.ToUpper();
                case "title":
                    return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                default:
                    throw new ArgumentException("Недопустимый режим. Используйте 'lower', 'upper' или 'title'.");
            }
        }

        public static (string Longest, string Shortest) FindLongestAndShortest(string text)
        {
            var separators = new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r' };
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return (null, null);

            var longest = words.OrderByDescending(w => w.Length).First();
            var shortest = words.OrderBy(w => w.Length).First();

            return (longest, shortest);
        }

        public static int CountWordOccurrences(string text, string word, bool caseSensitive)
        {
            var separators = new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r' };
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (!caseSensitive)
            {
                text = text.ToLower();
                word = word.ToLower();
                words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }

            return words.Count(w => w == word);
        }

        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

        }

        public static string RemoveSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string deleteTwoSpaces = input.Replace("  ", "");

            return deleteTwoSpaces.Trim();
        }
        public static int CountWords(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            string[] words = input.Split(new[] { ',' });
            return words.Length;

        }
        public static int CountCharacters(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? 0 : input.Length;
        }
        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            string cleaned = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleaned.SequenceEqual(cleaned.Reverse());
        }
        public static List<string> GetMostFrequentWords(string input, int topN = 3)
        {
            if (string.IsNullOrWhiteSpace(input)) return new List<string>();

            var words = Regex.Matches(input.ToLower(), @"\b\w+\b")
                .Cast<Match>()
                .Select(m => m.Value);

            return words.GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Take(topN)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
