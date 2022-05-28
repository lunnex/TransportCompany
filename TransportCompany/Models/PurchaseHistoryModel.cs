using Entities;
using System;
using System.Collections.Generic;

namespace TransportCompany.Models
{
    public class PurchaseHistoryModel
    {
        public List<Purchase> Purchases { get; set; }

        public PurchaseHistoryModel(List<Purchase> purchases)
        {
            Purchases = purchases;
        }
    }
}
