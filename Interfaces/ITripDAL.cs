using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ITripDAL
    {
        public Trip Get(int idTrip);
        public List<Trip> GetAll(string idPassenger);
        public List<TripViewModel> GetAllView(string idPassenger);
    }
}
