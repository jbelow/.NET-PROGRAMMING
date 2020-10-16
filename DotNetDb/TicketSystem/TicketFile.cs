using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;


namespace TicketSystem
{
    public class TicketFile
    {
        // public property
        public string filePath { get; set; }
        public List<Ticket> Ticket { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "nlog.config").GetCurrentClassLogger();


        // constructor is a special method that is invoked
        // when an instance of a class is created
        public TicketFile(string movieFilePath)
        {
            filePath = movieFilePath;
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
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)
                        string[] ticketDetails = line.Split(',');
                        ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                        ticket.title = ticketDetails[1];
                        ticket.genres = ticketDetails[2].Split('|').ToList();
                    }
                    else
                    {
                        // quote = comma in movie title
                        // extract the movieId
                        ticket.movieId = UInt64.Parse(line.Substring(0, idx - 1));
                        // remove movieId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the movieTitle
                        ticket.title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        ticket.genres = line.Split('|').ToList();
                    }
                    Ticket.Add(ticket);
                }
                // close file when done
                sr.Close();
                logger.Info("Movies in file {Count}", Ticket.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }


        public void AddTicket(Ticket ticket)
        {
            try
            {
                // first generate movie id
                ticket.ticketId = Ticket.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.severity}");
                sw.Close();
                // add ticket details to Lists
                Ticket.Add(ticket);
                // log transaction
                logger.Info("Movie id {Id} added", ticket.ticketId);
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
