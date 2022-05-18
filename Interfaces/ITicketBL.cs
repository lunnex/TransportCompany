using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITicketBL
    {
        public Ticket Get(int phonePassenger);
        public void Add(Ticket ticket);
    }
}
