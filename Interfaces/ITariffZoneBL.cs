using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ITariffZoneBL
    {
        public List<TariffZone> GetAll();
        public TariffZone Get(int id);
    }
}
