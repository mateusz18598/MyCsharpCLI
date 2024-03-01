using System;
using System.Net;

namespace CsharpCLIapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get computer username
            string computerName = Environment.MachineName;

            bool exit = false;

            while (exit==false)
            {
                // Display command prompt with computer name and wait for command input.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{computerName}:~$ ");
                Console.ForegroundColor = ConsoleColor.White;

                string option = Console.ReadLine().ToLower();

                // Handle the entered command.
                switch (option)
                {
                    default:
                        Console.WriteLine($"{option}: command not found");
                        break;
                    case "exit":
                        exit = true;
                        break;
                    case "help":
                        Help();
                        break;
                    case "ipconfig":
                        Ipconfig();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                }
            }
        }

        // Help
        static void Help()
        {
            Console.WriteLine("EXIT".PadRight(15) + "Quit the program");
            Console.WriteLine("HELP".PadRight(15) + "Provides Help information for CsharpCLI");
            Console.WriteLine("CLEAR".PadRight(15) + "Clears the screen");
            Console.WriteLine("IPCONFIG".PadRight(15) + "Displays the local IP address");

        }

        // Ipconfig
        static void Ipconfig()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostname);
            IPAddress[] ipAddresses = ipEntry.AddressList;

            foreach(IPAddress ipAddress in ipAddresses)
            {
                Console.WriteLine($"Local IP Address: {ipAddress}");
            }
        }
    }
}