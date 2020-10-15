﻿using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                menu();
            } while (true);

        }

        private static void menu()
        {
            int choice;

            Console.WriteLine("What fine do you want to work with:\n1) Tickets\n2) Enhancements\n3) Tasks");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.csv";


                    MovieFile movieFile = new MovieFile(movieFilePath);

                    Console.WriteLine("1) Write to the Tickets file\n2) Read from the Tickets file");
                    choice = Convert.ToInt32(Console.ReadLine());


                    if (choice == 1)
                    {
                        Ticket ticket = new Ticket();

                        // ask user to input ticket id
                        //TODO: change this later to make it get the last id
                        Console.WriteLine("Enter the ticket id");
                        ticket.ticketId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the summary");
                        ticket.summary = Console.ReadLine();

                        Console.WriteLine("Enter the status");
                        ticket.status = Console.ReadLine();

                        Console.WriteLine("Enter the priority");
                        ticket.priority = Console.ReadLine();

                        Console.WriteLine("Enter the submitter");
                        ticket.submitter = Console.ReadLine();

                        Console.WriteLine("Enter the assigned");
                        ticket.assigned = Console.ReadLine();

                        // input watching
                        string input;
                        do
                        {
                            // ask user to enter watching
                            Console.WriteLine("Enter people watching (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                ticket.watching.Add(input);
                            }
                        } while (input != "done");
                        // specify if no watching people are entered
                        if (ticket.watching.Count == 0)
                        {
                            ticket.watching.Add("(no one watching listed)");
                        }

                        // add ticket
                        movieFile.AddMovie(movie);



                    }
                    else if (choice == 2)
                    {

                    }

                    break;

                case 2:
                    Console.WriteLine("1) Write to the Enhancements file\n2) Read from the Enhancements file");
                    choice = Convert.ToInt32(Console.ReadLine());


                    break;

                case 3:
                    Console.WriteLine("1) Write to the Tasks file\n2) Read from the Tasks file");
                    choice = Convert.ToInt32(Console.ReadLine());


                    break;

                default:
                    Console.WriteLine("Please ");
                    break;

            }


            Console.WriteLine("Enter any other key to exit.");

        }


    }
}
