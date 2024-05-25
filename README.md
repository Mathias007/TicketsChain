`TicketsChain` - pseudocode:
```
class Ticket:
    def __init__(self, type, description):
        self.type = type
        self.description = description

interface ITicketHandler:
    method HandleTicket(ticket)
    method SetNextHandler(nextHandler)

class BaseTicketHandler implements ITicketHandler:
    attribute nextHandler

    method SetNextHandler(nextHandler):
        this.nextHandler = nextHandler
        return nextHandler

    method HandleTicket(ticket):
        if nextHandler is not None:
            nextHandler.HandleTicket(ticket)

class TechnicalSupportHandler extends BaseTicketHandler:
    method HandleTicket(ticket):
        if ticket.type == "Technical":
            print("TechnicalSupportHandler is handling the ticket: " + ticket.description)
        else:
            super.HandleTicket(ticket)

class BillingSupportHandler extends BaseTicketHandler:
    method HandleTicket(ticket):
        if ticket.type == "Billing":
            print("BillingSupportHandler is handling the ticket: " + ticket.description)
        else:
            super.HandleTicket(ticket)

class GeneralSupportHandler extends BaseTicketHandler:
    method HandleTicket(ticket):
        if ticket.type == "General":
            print("GeneralSupportHandler is handling the ticket: " + ticket.description)
        else:
            super.HandleTicket(ticket)

class Client:
    method Main():
        technicalSupportHandler = new TechnicalSupportHandler()
        billingSupportHandler = new BillingSupportHandler()
        generalSupportHandler = new GeneralSupportHandler()

        technicalSupportHandler.SetNextHandler(billingSupportHandler)
                               .SetNextHandler(generalSupportHandler)

        tickets = [
            new Ticket("Technical", "Cannot connect to the internet."),
            new Ticket("Billing", "Incorrect charge on my bill."),
            new Ticket("General", "How do I reset my password?"),
            new Ticket("Technical", "My computer is not turning on.")
        ]

        for ticket in tickets:
            technicalSupportHandler.HandleTicket(ticket)
```
