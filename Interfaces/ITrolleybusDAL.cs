using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITrolleybusDAL
    {
        public Trolleybus GetBus(string regNum);
        public List<Trolleybus> GetBuses();
    }
}
