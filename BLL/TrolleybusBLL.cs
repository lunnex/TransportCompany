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
    public class TrolleybusBLL : ITrolleybusBL
    {
        private readonly TrolleybusDAL _trolleybusDAL;

        public TrolleybusBLL(TrolleybusDAL trolleybusDAL)
        {
            _trolleybusDAL = trolleybusDAL;
        }

        public Trolleybus GetBus(string regNum)
        {
            return _trolleybusDAL.GetBus(regNum);
        }

        public List<Trolleybus> GetBuses()
        {
            return _trolleybusDAL.GetBuses();
        }
    }
}
