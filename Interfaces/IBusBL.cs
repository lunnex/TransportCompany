using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBusBL
    {
        public Bus GetBus(string regNum);
        public List<Bus> GetBuses();
    }
}
