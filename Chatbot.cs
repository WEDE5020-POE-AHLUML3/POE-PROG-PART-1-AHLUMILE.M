using CyberAwareBot.Handlers;
using System;
using System.Collections.Generic;

namespace CyberAwareBot
{
    public class Chatbot
    {
        private string name = "User";

        // Menu mapping: number -> (title, response)
        private readonly Dictionary<int, (string Title, string Response)> _menu = new()
        {
            { 1,  ("Passwords",     "Use strong passwords with letters, numbers, and symbols. Consider a password manager.") },
            { 2,  ("Phishing",      "Phishing is when attackers trick you into giving personal information. Verify senders and avoid suspicious links.") },
            { 3,  ("Safe browsing", "Only visit secure websites (https), avoid unknown links, and keep your browser updated.") },
            { 4,  ("Purpose",       "My purpose is to help you stay safe online and understand cybersecurity.") },
            { 5,  ("Two-factor auth","Enable two-factor authentication (2FA) to add an extra layer of protection to your accounts.") },
            { 6,  ("Social engineering", "Social engineering tricks you into revealing information. Be skeptical of unexpected requests." ) },
            { 7,  ("Malware",       "Malware is software designed to harm or control devices. Keep software updated and use reputable antivirus.") },
            { 8,  ("Ransomware",    "Ransomware encrypts your files and demands payment. Keep backups and avoid executing unknown attachments.") },
            { 9,  ("Updates",       "Install OS and app updates regularly to patch vulnerabilities.") },
            { 10, ("Wi-Fi security", "Use strong Wi‑Fi passwords, WPA3/WPA2, and avoid public Wi‑Fi for sensitive tasks.") },
            { 11, ("Backups",       "Keep regular offline or cloud backups of important data and test restore procedures.") },
            { 12, ("Privacy",       "Limit data sharing, check app permissions, and use privacy settings on services.") },
            { 13, ("Encryption",    "Use device and communication encryption (e.g., full-disk and TLS) to protect data in transit and at rest.") },
            { 14, ("Safe links",    "Hover links to inspect destinations, and avoid shortened/obscured URLs from unknown sources.") },
            { 15, ("Accounts",      "Use unique passwords per account and review account activity regularly.") },
            { 16, ("Scamming",      "Scamming is fraud: attackers deceive victims into sending money or sensitive info. Verify identities and never share credentials.") }
        };

        // When true, the bot is waiting for the user to enter a menu number.
        private bool _awaitingMenuSelection;

        public void Run()
        {
            ConsoleUI.ShowHeader();
            AskName();

            while (true)
            {
                ConsoleUI.UserPrompt();
                string? input = Console.ReadLine();

                if (!InputValidator.Check(input))
                {
                    // Input validation: detect and respond to empty/invalid entries.
                    ConsoleUI.BotReply("I didn't receive any input. Please type something or 'exit' to quit.");
                    continue;
                }

                // Normalize input safely to avoid null dereference
                string normalizedInput = (input ?? string.Empty).Trim().ToLowerInvariant();

                // Immediate exit
                if (normalizedInput == "exit")
                {
                    ConsoleUI.BotReply("Goodbye! Stay safe online.");
                    break;
                }

                // If awaiting a numeric menu selection, handle that first.
                if (_awaitingMenuSelection)
                {
                    string menuResponse = HandleMenuSelection(normalizedInput);
                    ConsoleUI.BotReply(menuResponse);
                    continue;
                }

                // If the user asks what they can ask, show the menu and set awaiting state.
                if (normalizedInput == "what can i ask" ||
                    normalizedInput == "what can i ask you" ||
                    normalizedInput == "what can i ask you about" ||
                    normalizedInput.Contains("what can i ask") ||
                    normalizedInput.Contains("what can i ask you") ||
                    normalizedInput.Contains("help"))
                {
                    ConsoleUI.ShowMenu(_menu);
                    _awaitingMenuSelection = true;
                    ConsoleUI.BotReply("Please enter the number of the topic you want to learn about (1-16), or type 'exit'.")
;
                    continue;
                }

                // Otherwise use the basic response logic from the guide.
                string response = GetBasicResponse(normalizedInput, name);
                ConsoleUI.BotReply(response);
            }
        }

        private string HandleMenuSelection(string input)
        {
            if (int.TryParse(input, out int choice))
            {
                _awaitingMenuSelection = false;

                if (_menu.TryGetValue(choice, out var entry))
                {
                    ConsoleUI.Divider();
                    return entry.Response + "  \nIf you'd like another topic, ask 'what can I ask you about' again.";
                }

                return "Unknown menu choice. Enter a number between 1 and 16, or type 'exit'.";
            }

            return "Please enter a number from the menu (1-16) or type 'exit' to quit.";
        }

        // Implement the simple example logic from the guide.
        private string GetBasicResponse(string input, string name)
        {
            // Exact match per the example
            if (input == "how are you" || input == "how are you?")
                return "I'm just code, but I'm here to help you!";

            // Purpose check
            if (input.Contains("purpose") || input.Contains("what is your purpose") || input.Contains("what's your purpose"))
                return "My purpose is to help you stay safe online and understand cybersecurity.";

            // Keyword checks
            if (input.Contains("password"))
                return "Use strong passwords with symbols and numbers. Consider a password manager.";

            if (input.Contains("phishing"))
                return "Do not click suspicious links in emails. Verify the sender and check URLs.";

            if (input.Contains("browsing") || input.Contains("safe browsing"))
                return "Only visit secure websites (https), avoid suspicious links, and keep your browser updated.";

            // Default response for unknown queries
            return "I didn't quite understand that. Could you rephrase?";
        }

        private void AskName()
        {
            ConsoleUI.BotReply("Hello!");
            ConsoleUI.BotReply("I am here to help you stay secure online.");
            ConsoleUI.BotReply("Please enter your name:");

            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                name = input.Trim();

            ConsoleUI.BotReply($"Welcome, {name}! Ask 'what can I ask you about' to see available topics.");
        }
    }
}