using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ITariffBL
    {
        public List<Tariff> GetAll();
        public Tariff Get(int id);
    }
}
