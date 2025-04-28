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

    }
}
