using System;
using System.Collections.Generic;

namespace TicketSystem
{
    public abstract class TicketType
    {
        // public properties
        public UInt64 ticketId { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }

        // constructor
        public TicketType()
        {
            watching = new List<string>();
        }

        // public method
        public virtual string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}";
        }
    }

    // Ticket class is derived from TicketType class
    public class Ticket : TicketType
    {
        public string severity { get; set; }

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSeverity: {severity}";

        }
    }

    // Enhancement class is derived from TicketType class
    public class Enhancement : TicketType
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public string estimate { get; set; }

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}";

        }
    }

    // Task class is derived from TicketType class
    public class Task : TicketType
    {
        public string projectName { get; set; }
        public DateTime dueDate { get; set; }

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nProject Name: {projectName}\nDue Date: {dueDate}";

        }
    }
}
