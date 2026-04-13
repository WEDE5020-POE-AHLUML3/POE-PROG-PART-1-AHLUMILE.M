namespace CyberAwareBot.Handlers
{
    // Centralized input validation used by Chatbot.
    public static class InputValidator
    {
        public static bool Check(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}