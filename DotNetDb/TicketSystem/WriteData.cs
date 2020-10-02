using System;
using System.IO;

public class WriteData{ 


    public void NewTicket() {
        AccessData access = new AccessData();
        string dataFile = access.AccessDataFile;

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
