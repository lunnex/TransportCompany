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
    public class WaybillBLL : IWaybillBL
    {
        private readonly WaybillDAL _waybillDAL;

        public WaybillBLL(WaybillDAL busDAL)
        {
            _waybillDAL = busDAL;
        }

        public List<Waybill> GetWaybills()
        {
            return _waybillDAL.GetWaybills();
        }
    }
}
