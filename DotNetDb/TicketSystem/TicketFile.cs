using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TicketSystem
{
    public class TicketFile
    {
        // public property
        public string filePath { get; set; }
        public List<Ticket> Ticket { get; set; }


        // constructor is a special method that is invoked
        // when an instance of a class is created
        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Ticket = new List<Ticket>();

            // to populate the list with data, read from the data file
            try
            {
                StreamReader sr = new StreamReader(filePath);

                // first line contains column headers
                sr.ReadLine();
                
                while (!sr.EndOfStream)
                {

                    // create instance of Ticket class
                    Ticket ticket = new Ticket();

                    string line = sr.ReadLine();


                    // no quote = no comma in ticket title
                    // ticket details are separated with comma(,)
                    
                    // Console.WriteLine("1");

                    string[] ticketDetails = line.Split(',');
                    // Console.WriteLine("2");
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    // Console.WriteLine("3");
                    ticket.summary = ticketDetails[1];
                    // Console.WriteLine("4");
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();
                    ticket.severity = ticketDetails[7];
                    // Console.WriteLine("5");
                    

                    Console.WriteLine(ticket.summary);


                    Ticket.Add(ticket);
                }
                // close file when done
                sr.Close();
                Console.WriteLine("Tickets in file {0}", Ticket.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("the catch happened for the TicketFile");
                Console.WriteLine(ex.Message);
            }
        }


        public void AddTicket(Ticket ticket)
        {
            try
            {
                Console.WriteLine("trying to write a new line");
                // first generate ticket id
                ticket.ticketId = Ticket.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);

                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.severity}");
                sw.Close();

                // add ticket details to Lists
                Ticket.Add(ticket);

                // log transaction
                Console.WriteLine("Ticket id {0} added", ticket.ticketId);

            } 
            catch(Exception ex)
            {
                Console.WriteLine("the catch happened for AddTicket");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
