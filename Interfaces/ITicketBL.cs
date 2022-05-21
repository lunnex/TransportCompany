using Entities;

namespace Interfaces
{
    public interface ITicketBL
    {
        public Ticket Get(string phonePassenger);
        public void Add(Ticket ticket);
    }
}
