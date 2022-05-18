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
    public class TariffZoneBLL : ITariffZoneBL
    {
        private readonly TariffZoneDAL _tariffZoneDAL;

        public TariffZoneBLL(TariffZoneDAL tariffZoneDAL)
        {
            _tariffZoneDAL = tariffZoneDAL;
        }
        public TariffZone Get(int id)
        {
            return _tariffZoneDAL.Get(id);
        }

        public List<TariffZone> GetAll()
        {
            return _tariffZoneDAL.GetAll();
        }
    }
}
