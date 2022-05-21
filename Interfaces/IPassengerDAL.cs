using Entities;

namespace Interfaces
{
    public interface IPassengerDAL
    {
        public Passenger Get(string phoneNumber);
        public void Add(Passenger passenger);
    }
}
