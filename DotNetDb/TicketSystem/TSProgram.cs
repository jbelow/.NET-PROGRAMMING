using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFile;
            AccessData access = new AccessData();
            string choice = "";

            do
            {
                if (access.doesFileExist())
                {
                    dataFile = access.AccessDataFile;

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
                        string newTicket = "";
                        int assigned;

                        StreamWriter sw = new StreamWriter(dataFile, true);

                        Console.WriteLine("Enter the ticketID.");
                        string userInput = Console.ReadLine();
                        newTicket += userInput;

                        Console.WriteLine("Enter the summary.");
                        userInput = Console.ReadLine();
                        newTicket += ", " + userInput;

                        Console.WriteLine("Enter the status.");
                        userInput = Console.ReadLine();
                        newTicket += ", " + userInput;

                        Console.WriteLine("Enter the priority.");
                        userInput = Console.ReadLine();
                        newTicket += ", " + userInput;

                        Console.WriteLine("Enter the submitter.");
                        userInput = Console.ReadLine();
                        newTicket += ", " + userInput;

                        Console.WriteLine("How many people are going to be assigned?");
                        userInput = Console.ReadLine();
                        assigned = Convert.ToInt32(userInput);

                        for (int j = 0; j < assigned; j++)
                        {
                            Console.WriteLine("Enter the assigned person.");
                            userInput = Console.ReadLine();
                            newTicket += "| " + userInput;
                        }

                        Console.WriteLine(newTicket);

                        sw.WriteLine(newTicket);

                        sw.Close();
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
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create new ticket from data.");
            Console.WriteLine("Enter any other key to exit.");
        }





    }
}
