using DAL;
using Entities;
using Interfaces;

namespace BLL
{
    public class TicketBLL : ITicketBL
    {
        private readonly TicketDAL _ticketDAL;

        public TicketBLL(TicketDAL TicketDAL)
        {
            _ticketDAL = TicketDAL;
        }
        public void Add(Ticket ticket)
        {
            _ticketDAL.Add(ticket);
        }

        public Ticket Get(string phonePassenger)
        {
            return _ticketDAL.Get(phonePassenger);
        }
    }
}
