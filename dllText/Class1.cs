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

    }
}
