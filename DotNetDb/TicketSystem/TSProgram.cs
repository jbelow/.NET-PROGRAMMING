using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessData access = new AccessData();
            string choice = "";

            do
            {
                if (access.DoesFileExist())
                {
                    string dataFile = access.AccessDataFile;

                    printMenu();
                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        // ReadData writing = new ReadData();

                        // writing.OutputData();

                        StreamReader sr = new StreamReader(dataFile);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }

                    else if (choice == "2")
                    {
                        WriteData ticket = new WriteData();
                        ticket.NewTicket();

                    }
                }
                else
                {
                    Console.WriteLine("Error: File does not exists");
                }

            } while (choice == "1" || choice == "2");

        }

        private static void printMenu()
        {
            //abstracting out the menu
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create new ticket from data.");
            Console.WriteLine("Enter any other key to exit.");
        }





    }
}
