using DAL;
using Entities;
using Interfaces;
using System.Collections.Generic;

namespace BLL
{
    public class TripBLL : ITripBL
    {
        private readonly TripDAL _tripDAL;

        public TripBLL(TripDAL TripDAL)
        {
            _tripDAL = TripDAL;
        }

        public Trip Get(int idTrip)
        {
            return _tripDAL.Get(idTrip);
        }

        public List<Trip> GetAll(string idPassenger)
        {
            return _tripDAL.GetAll(idPassenger);
        }

        public List<TripViewModel> GetAllView(string idPassenger)
        {
            return _tripDAL.GetAllView(idPassenger);
        }
    }
}
