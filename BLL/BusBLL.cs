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
    public class BusBLL : IBusBL
    {
        private readonly BusDAL _busDAL;

        public BusBLL(BusDAL busDAL)
        {
            _busDAL = busDAL;
        }

        public List<Bus> GetBuses()
        {
            return _busDAL.GetBuses();
        }

        public Bus GetBus(string regNum)
        {
            return _busDAL.GetBus(regNum);
        }
    }
}
