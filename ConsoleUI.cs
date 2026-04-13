using System;
using System.Threading;
using System.Collections.Generic;

namespace CyberAwareBot
{
    public static class ConsoleUI
    {
        public static void ShowHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
$$$$$$\            $$\                                                      
$$  __$$\           $$ |                                                     
$$ /  \__|$$\   $$\ $$$$$$$\   $$$$$$\   $$$$$$\                             
$$ |      $$ |  $$ |$$  __$$\ $$  __$$\ $$  __$$\                            
$$ |      $$ |  $$ |$$ |  $$ |$$$$$$$$ |$$ |  \__|                           
$$ |  $$\ $$ |  $$ |$$ |  $$ |$$   ____|$$ |                                 
\$$$$$$  |\$$$$$$$ |$$$$$$$  |\$$$$$$$\ $$ |                                 
 \______/  \____$$ |\_______/  \_______|\__|                                 
          $$\   $$ |                                                         
          \$$$$$$  |                                                         
           \______/                                                          
                                                $$$$$$$\             $$\     
                                                $$  __$$\            $$ |    
                                                $$ |  $$ | $$$$$$\ $$$$$$\   
                                                $$$$$$$\ |$$  __$$\\_$$  _|  
                                                $$  __$$\ $$ /  $$ | $$ |    
                                                $$ |  $$ |$$ |  $$ | $$ |$$\ 
                                                $$$$$$$  |\$$$$$$  | \$$$$  |
                                                \_______/  \______/   \____/ 
                                                                             
                                                                            
                                                                             "); ;

            Console.WriteLine("========================================");
            Console.WriteLine("         CYBER AWARE CHATBOT");
            Console.WriteLine("========================================");
            Console.WriteLine("Type 'exit' anytime to quit");
            Console.WriteLine();

            Console.ResetColor();
        }

        public static void BotReply(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (char c in "Bot ➤ " + message)
            {
                Console.Write(c);
                Thread.Sleep(8);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public static void UserPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You ➤ ");
            Console.ResetColor();
        }

        public static void ShowSection(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"   {title.ToUpperInvariant()}");
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();
        }

        public static void ShowMenu(Dictionary<int, (string Title, string Response)> menu)
        {
            ShowSection("Available Topics");
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var kv in menu)
            {
                Console.WriteLine($"{kv.Key,2}: {kv.Value.Title}");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Divider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();
        }
    }
}