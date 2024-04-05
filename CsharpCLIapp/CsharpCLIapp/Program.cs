using System;
using System.Net;
using System.IO;

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
                    case "exit": // Quit the program
                        exit = true;
                        break;
                    case "help":
                        Help();
                        break;
                    case "ipconfig":
                        Ipconfig();
                        break;
                    case "clear": // Clears the screen
                        Console.Clear();
                        break;
                    case "time": // Displays the current time
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "touch":
                        string fileName = "";

                        while (string.IsNullOrWhiteSpace(fileName))
                        {
                            Console.Write("Enter your file name: ");
                            fileName = Console.ReadLine();
                        }
                        Touch(fileName);
                        break;
                    case "mkdir":
                        string dirName = "";

                        while (string.IsNullOrWhiteSpace(dirName))
                        {
                            Console.Write("Enter your file name: ");
                            dirName = Console.ReadLine();
                        }
                        Mkdir(dirName);
                        break;

                }
            }
        }

        // Help - Provides Help information for CsharpCLI
        static void Help()
        {
            Console.WriteLine("EXIT".PadRight(15) + "Quit the program");
            Console.WriteLine("HELP".PadRight(15) + "Provides Help information for CsharpCLI");
            Console.WriteLine("CLEAR".PadRight(15) + "Clears the screen");
            Console.WriteLine("IPCONFIG".PadRight(15) + "Displays the local IP address");
            Console.WriteLine("TIME".PadRight(15) + "Displays the current time");
            Console.WriteLine("TOUCH".PadRight(15) + "Creates a .txt file");
            Console.WriteLine("MKDIR".PadRight(15) + "Creates a directory");
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

        // Touch
        static void Touch(string fileName)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(fileName+ ".txt");
                {
                    Console.WriteLine($"File: {fileName}.txt has been created");
                }
            }
            catch 
            {
                Console.WriteLine("An error occured");
            }
        }

        //Mkdir 
        static void Mkdir(string fileName)
        {
            try
            {
                if(Directory.Exists(fileName))
                {
                    Console.WriteLine("Directory exists already");
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(fileName);
                    Console.WriteLine("Directory has been created");
                }

            }
            catch
            {
                Console.WriteLine($"The process failed");
            }
        }
    }
}