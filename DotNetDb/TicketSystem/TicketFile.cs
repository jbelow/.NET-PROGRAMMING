using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using NLog.Web;


namespace TicketSystem
{
    public class TicketFile
    {
        // public property
        public string filePath { get; set; }
        public List<Ticket> Ticket { get; set; }
        // private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "nlog.config").GetCurrentClassLogger();


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
                    string[] ticketDetails = line.Split(',');
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();
                    ticket.severity = ticketDetails[7];


                    Ticket.Add(ticket);
                }
                // close file when done
                sr.Close();
                // logger.Info("Tickets in file {Count}", Ticket.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // logger.Error(ex.Message);
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
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.severity}");
                sw.Close();
                // add ticket details to Lists
                Ticket.Add(ticket);
                // log transaction
                Console.WriteLine("Ticket id {Id} added", ticket.ticketId);
                // logger.Info("Ticket id {Id} added", ticket.ticketId);
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                // logger.Error(ex.Message);
            }
        }
    }
}
