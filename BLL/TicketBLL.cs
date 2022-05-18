using DAL;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Ticket Get(int phonePassenger)
        {
            return _ticketDAL.Get(phonePassenger);
        }
    }
}
