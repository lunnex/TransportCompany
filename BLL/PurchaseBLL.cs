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
    public class PurchaseBLL : IPurchaseBL
    {
        private readonly PurchseDAL _purchaseDAL;

        public PurchaseBLL(PurchseDAL purchaseDAL)
        {
            _purchaseDAL = purchaseDAL;
        }

        public List<Purchase> GetPurchases(string passenger)
        {
            return _purchaseDAL.GetPurchases(passenger);
        }
    }
}
