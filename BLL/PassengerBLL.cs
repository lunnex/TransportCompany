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
    public class PassengerBLL : IPassengerBL
    {
        private readonly PassengerDAL _passengeDAL;

        public PassengerBLL(PassengerDAL passengerDAL)
        {
            _passengeDAL = passengerDAL;
        }

        public void Add(Passenger passenger)
        {
            _passengeDAL.Add(passenger);
        }

        public Passenger Get(string phoneNumber)
        {
            return _passengeDAL.Get(phoneNumber);
        }
    }
}
