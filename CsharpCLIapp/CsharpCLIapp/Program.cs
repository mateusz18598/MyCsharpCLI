using System;

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
                }
            }
        }

        // Help
        static void Help()
        {
            Console.WriteLine("EXIT".PadRight(15) + "Quit the program");
            Console.WriteLine("HELP".PadRight(15) + "Provides Help information for CsharpCLI");
        }
    }
}