using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITariffZoneDAL
    {
        public List<TariffZone> GetAll();
        public TariffZone Get(int id);
    }
}
