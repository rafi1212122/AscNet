namespace AscNet.Logging
{
    public static class LoggingExtensions
    {
        public static string RemoveBefore(this string value, char character)
        {
            int index = value.LastIndexOf(character);
            if (index > 0)
            {
                value = value[(index + 1)..];
            }

            return value;
        }
    }
}
