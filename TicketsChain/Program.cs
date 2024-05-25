using System;

namespace TicketsChain
{
    public class Ticket
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public Ticket(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }

    public interface ITicketHandler
    {
        void HandleTicket(Ticket ticket);
        ITicketHandler SetNextHandler(ITicketHandler nextHandler);
    }

    public abstract class BaseTicketHandler : ITicketHandler
    {
        private ITicketHandler nextHandler;

        public virtual void HandleTicket(Ticket ticket)
        {
            if (nextHandler != null)
            {
                nextHandler.HandleTicket(ticket);
            }
        }

        public ITicketHandler SetNextHandler(ITicketHandler nextHandler)
        {
            this.nextHandler = nextHandler;
            return nextHandler;
        }
    }

    public class TechnicalSupportHandler : BaseTicketHandler
    {
        public override void HandleTicket(Ticket ticket)
        {
            if (ticket.Type == "Technical")
            {
                Console.WriteLine("TechnicalSupportHandler is handling the ticket: " + ticket.Description);
            }
            else
            {
                base.HandleTicket(ticket);
            }
        }
    }

    public class BillingSupportHandler : BaseTicketHandler
    {
        public override void HandleTicket(Ticket ticket)
        {
            if (ticket.Type == "Billing")
            {
                Console.WriteLine("BillingSupportHandler is handling the ticket: " + ticket.Description);
            }
            else
            {
                base.HandleTicket(ticket);
            }
        }
    }

    public class GeneralSupportHandler : BaseTicketHandler
    {
        public override void HandleTicket(Ticket ticket)
        {
            if (ticket.Type == "General")
            {
                Console.WriteLine("GeneralSupportHandler is handling the ticket: " + ticket.Description);
            }
            else
            {
                base.HandleTicket(ticket);
            }
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            ITicketHandler technicalSupportHandler = new TechnicalSupportHandler();
            ITicketHandler billingSupportHandler = new BillingSupportHandler();
            ITicketHandler generalSupportHandler = new GeneralSupportHandler();

            technicalSupportHandler.SetNextHandler(billingSupportHandler)
                                   .SetNextHandler(generalSupportHandler);

            Ticket[] tickets = {
            new Ticket("Technical", "Cannot connect to the internet."),
            new Ticket("Billing", "Incorrect charge on my bill."),
            new Ticket("General", "How do I reset my password?"),
            new Ticket("Technical", "My computer is not turning on.")
        };

            foreach (var ticket in tickets)
            {
                technicalSupportHandler.HandleTicket(ticket);
            }
        }
    }
}
