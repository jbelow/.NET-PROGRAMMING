using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Ticket.csv";
            string choice = "";
            
            do {

            if(File.Exists (file)){
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("Enter any other key to exit.");
            choice = Console.ReadLine();


            if (choice == "1") {

                StreamReader sr = new StreamReader(file);
                while(!sr.EndOfStream){
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                    // // convert string to array
                    // string[] arr = line.Split(',');
                    // Console.WriteLine(arr[0], arr[1], arr[2], arr[3]);
                }
            }

            else if (choice == "2") {
                    string newTicket = "";

                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 7; i++) {
                        

                        // ask a question
                        Console.WriteLine("Enter new ticket (Y/N)?");
                        // input the response
                        string response = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (response != "Y") { break; }

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

                        Console.WriteLine("Enter the assigned person.");
                        userInput = Console.ReadLine();
                        newTicket += ", " + userInput; 

                        Console.WriteLine(newTicket);


                        
                        // sw.WriteLine("{0}|{1}", name, grade);
                    }
                    sw.Close();
            }

            } else { //if else check for file
                Console.WriteLine("Error: File does not exists");
            }       

            } while (choice == "1" || choice == "2");


        

           



        }
    }
}
