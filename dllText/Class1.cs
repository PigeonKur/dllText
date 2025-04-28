namespace dllText
{
    public class Class
    {
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
    }
}
