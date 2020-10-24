using System;
using System.IO;
using System.Linq;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string ticketFilePath = "tickets.csv";
            TicketFile ticketFile = new TicketFile(ticketFilePath);

            string enhancementFilePath = "enhancements.csv";
            EnhancementFile enhancementFile = new EnhancementFile(enhancementFilePath);

            string taskFilePath = "tasks.csv";
            TaskFile taskFile = new TaskFile(taskFilePath);

            do
            {
                Console.WriteLine("What file do you want to work with:\n1) Tickets\n2) Enhancements\n3) Tasks\n4) Search Files\n5) Exit the program");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:



                        Console.WriteLine("1) Write to the Tickets file\n2) Read from the Tickets file");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {
                            Ticket ticket = new Ticket();

                            // ask user to input ticket info
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

                            Console.WriteLine("Enter the severity");
                            ticket.severity = Console.ReadLine();


                            // add ticket
                            ticketFile.AddTicket(ticket);

                        }
                        else if (choice == 2)
                        {

                            // Display all tickets
                            foreach (Ticket t in ticketFile.Ticket)
                            {
                                Console.WriteLine(t.Display());
                            }
                        }

                        break;

                    case 2:



                        Console.WriteLine("1) Write to the Enhancements file\n2) Read from the Enhancements file");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {
                            Enhancement enhancement = new Enhancement();

                            // ask user to input ticket info
                            Console.WriteLine("Enter the summary");
                            enhancement.summary = Console.ReadLine();

                            Console.WriteLine("Enter the status");
                            enhancement.status = Console.ReadLine();

                            Console.WriteLine("Enter the priority");
                            enhancement.priority = Console.ReadLine();

                            Console.WriteLine("Enter the submitter");
                            enhancement.submitter = Console.ReadLine();

                            Console.WriteLine("Enter the assigned");
                            enhancement.assigned = Console.ReadLine();

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
                                    enhancement.watching.Add(input);
                                }
                            } while (input != "done");
                            // specify if no watching people are entered
                            if (enhancement.watching.Count == 0)
                            {
                                enhancement.watching.Add("(no one watching listed)");
                            }

                            Console.WriteLine("Enter the software");
                            enhancement.software = Console.ReadLine();

                            Console.WriteLine("Enter the cost");
                            enhancement.cost = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the reason");
                            enhancement.reason = Console.ReadLine();

                            Console.WriteLine("Enter the estimate");
                            enhancement.estimate = Console.ReadLine();

                            // add enhancement
                            enhancementFile.AddEnhancement(enhancement);

                        }
                        else if (choice == 2)
                        {

                            // Display all enhancements
                            foreach (Enhancement e in enhancementFile.Enhancement)
                            {
                                Console.WriteLine(e.Display());
                            }
                        }

                        break;

                    case 3:


                        Console.WriteLine("1) Write to the Task file\n2) Read from the Task file");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {
                            Task task = new Task();

                            // ask user to input ticket info
                            Console.WriteLine("Enter the summary");
                            task.summary = Console.ReadLine();

                            Console.WriteLine("Enter the status");
                            task.status = Console.ReadLine();

                            Console.WriteLine("Enter the priority");
                            task.priority = Console.ReadLine();

                            Console.WriteLine("Enter the submitter");
                            task.submitter = Console.ReadLine();

                            Console.WriteLine("Enter the assigned");
                            task.assigned = Console.ReadLine();

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
                                    task.watching.Add(input);
                                }
                            } while (input != "done");
                            // specify if no watching people are entered
                            if (task.watching.Count == 0)
                            {
                                task.watching.Add("(no one watching listed)");
                            }

                            Console.WriteLine("Enter the project name");
                            task.projectName = Console.ReadLine();

                            Console.WriteLine("Enter the due date");
                            task.dueDate = DateTime.Parse(Console.ReadLine());

                            // add task
                            taskFile.AddTask(task);

                        }
                        else if (choice == 2)
                        {

                            // Display all tasks
                            foreach (Task t in taskFile.Task)
                            {
                                Console.WriteLine(t.Display());
                            }
                        }

                        break;

                    case 4:
                        string search = "";

                        Console.WriteLine("What in the system to you want to search:\n1) status\n2) priority\n3) submitter");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {

                            Console.WriteLine("What is the status of the ticket you want to search:");
                            search = Console.ReadLine().ToLower();

                            var ticketSearch = ticketFile.Ticket.Where(t => t.status.ToLower().Contains($"{search}"));
                            Console.WriteLine($"There are {ticketSearch.Count()} tickets with \"{search}\" in the status:");
                            foreach (Ticket t in ticketSearch)
                            {
                                Console.WriteLine($" {t.status}");
                            }

                            var taskSearch = taskFile.Task.Where(t => t.status.Contains($"{search}"));
                            Console.WriteLine($"There are {taskSearch.Count()} tasks with \"{search}\" in the status:");
                            foreach (Task t in taskSearch)
                            {
                                Console.WriteLine($" {t.status}");
                            }

                            var enhanncementsSearch = enhancementFile.Enhancement.Where(t => t.status.Contains($"{search}"));
                            Console.WriteLine($"There are {enhanncementsSearch.Count()} enhanncements with \"{search}\" in the status:");
                            foreach (Enhancement t in enhanncementsSearch)
                            {
                                Console.WriteLine($" {t.status}");
                            }

                        }
                        else if (choice == 2)
                        {

                            Console.WriteLine("What is the priority of the ticket you want to search:");
                            search = Console.ReadLine().ToLower();

                            var ticketSearch = ticketFile.Ticket.Where(t => t.priority.ToLower().Contains($"{search}"));
                            Console.WriteLine($"There are {ticketSearch.Count()} tickets with \"{search}\" in the priority:");
                            foreach (Ticket t in ticketSearch)
                            {
                                Console.WriteLine($" {t.priority}");
                            }

                            var taskSearch = taskFile.Task.Where(t => t.priority.Contains($"{search}"));
                            Console.WriteLine($"There are {taskSearch.Count()} tasks with \"{search}\" in the priority:");
                            foreach (Task t in taskSearch)
                            {
                                Console.WriteLine($" {t.priority}");
                            }

                            var enhanncementsSearch = enhancementFile.Enhancement.Where(t => t.priority.Contains($"{search}"));
                            Console.WriteLine($"There are {enhanncementsSearch.Count()} enhanncements with \"{search}\" in the priority:");
                            foreach (Enhancement t in enhanncementsSearch)
                            {
                                Console.WriteLine($" {t.priority}");
                            }

                        }
                        else if (choice == 3)
                        {
                            Console.WriteLine("What is the submitter of the ticket you want to search:");
                            search = Console.ReadLine().ToLower();

                            var ticketSearch = ticketFile.Ticket.Where(t => t.submitter.ToLower().Contains($"{search}"));
                            Console.WriteLine($"There are {ticketSearch.Count()} tickets with \"{search}\" in the submitter:");
                            foreach (Ticket t in ticketSearch)
                            {
                                Console.WriteLine($" {t.submitter}");
                            }

                            var taskSearch = taskFile.Task.Where(t => t.submitter.Contains($"{search}"));
                            Console.WriteLine($"There are {taskSearch.Count()} tasks with \"{search}\" in the submitter:");
                            foreach (Task t in taskSearch)
                            {
                                Console.WriteLine($" {t.submitter}");
                            }

                            var enhanncementsSearch = enhancementFile.Enhancement.Where(t => t.submitter.Contains($"{search}"));
                            Console.WriteLine($"There are {enhanncementsSearch.Count()} enhanncements with \"{search}\" in the submitter:");
                            foreach (Enhancement t in enhanncementsSearch)
                            {
                                Console.WriteLine($" {t.submitter}");
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Please enter one of the options");
                        break;

                }

            } while (choice != 5);

        }


    }
}
