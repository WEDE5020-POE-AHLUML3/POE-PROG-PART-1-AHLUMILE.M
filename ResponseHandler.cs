namespace CyberAwareBot
{
    public static class ResponseHandler
    {
        public static string Handle(string input, string name)
        {
            // HOW ARE YOU
            if (input.Contains("how are you"))
                return $"I'm doing really well, {name}! Thanks for asking. I'm here and ready to help you learn more about staying safe and secure while using the internet.";

            // PURPOSE
            if (input.Contains("purpose"))
                return "My main purpose is to help you understand important cybersecurity concepts and guide you on how to protect your personal information and devices from online threats such as hackers and scams.";

            // WHAT CAN I ASK
            if (input.Contains("what can i ask") || input.Contains("help"))
                return "You can ask me about a variety of cybersecurity topics such as how to create strong passwords, how phishing scams work, and how to browse the internet safely without putting your personal information at risk.";

            // PASSWORD
            if (input.Contains("password"))
                return "A strong password should be long, unique, and include a mix of uppercase letters, lowercase letters, numbers, and special characters. It is also important to avoid using personal information like your name or birthdate, and never reuse passwords across multiple accounts.";

            // PHISHING
            if (input.Contains("phishing"))
                return "Phishing is a type of cyber attack where attackers try to trick you into revealing sensitive information, such as passwords or banking details, by pretending to be a trustworthy source. Always be cautious of unexpected emails or messages and avoid clicking suspicious links.";

            // SAFE BROWSING
            if (input.Contains("browsing"))
                return "Safe browsing involves making sure that the websites you visit are secure, which usually means they start with 'https'. You should also avoid downloading files from unknown sources and be careful when clicking on links, especially in emails or pop-up messages.";

            // EXIT
            if (input == "exit")
                return "It was great chatting with you. Goodbye and remember to always stay safe online!";

            // DEFAULT
            return $"I'm not sure I fully understood that, {name}. You can try asking me about topics like passwords, phishing, or safe browsing, and I’ll do my best to help you.";
        }
    }
}