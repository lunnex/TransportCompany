using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPassengerDAL
    {
        public Passenger Get(string phoneNumber);
        public void Add(Passenger passenger);
    }
}
