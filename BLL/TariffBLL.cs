using DAL;
using Entities;
using Interfaces;
using System.Collections.Generic;

namespace BLL
{
    public class TariffBLL : ITariffBL
    {
        private readonly TariffDAL _tariffDAL;

        public TariffBLL(TariffDAL tariffDAL)
        {
            _tariffDAL = tariffDAL;
        }

        public Tariff Get(int id)
        {
            return _tariffDAL.Get(id);
        }

        public List<Tariff> GetAll()
        {
            return _tariffDAL.GetAll();
        }
    }
}
