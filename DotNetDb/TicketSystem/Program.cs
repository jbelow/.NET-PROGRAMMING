using System;
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


            // AccessData access = new AccessData();
            // string choice = "";

            // do
            // {
            //     if (access.DoesFileExist())
            //     {
            //         string dataFile = access.AccessDataFile;

            //         printMenu();
            //         choice = Console.ReadLine();

            //         if (choice == "1")
            //         {
            //             ReadData writing = new ReadData();
            //             writing.OutputData();


            //         }

            //         else if (choice == "2")
            //         {
            //             WriteData ticket = new WriteData();
            //             ticket.NewTicket();

            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("Error: File does not exists");
            //     }

            // } while (choice == "1" || choice == "2");

        }

        private static void menu()
        {
            int choice;

            Console.WriteLine("What fine do you want to work with:\n1) Tickets\n2) Enhancements\n3) Tasks");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("1) Write to the Tickets file\n2) Read from the Tickets file");
                    choice = Convert.ToInt32(Console.ReadLine());


                    if (choice == 1)
                    {
                        Ticket ticket = new Ticket();

                        // ask user to input ticket id
                        //TODO: change this later to make it get the last id
                        Console.WriteLine("Enter the ticket id");
                        ticket.ticketId = Console.ReadLine();


                        // input genres
                        string input;
                        do
                        {
                            // ask user to enter genre
                            Console.WriteLine("Enter genre (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                movie.genres.Add(input);
                            }
                        } while (input != "done");
                        // specify if no genres are entered
                        if (movie.genres.Count == 0)
                        {
                            movie.genres.Add("(no genres listed)");
                        }

                        Console.WriteLine("Enter movie director");
                        movie.director = Console.ReadLine();

                        Console.WriteLine("Enter running time (h:m:s)");
                        movie.runningTime = TimeSpan.Parse(Console.ReadLine());

                        // add movie
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
