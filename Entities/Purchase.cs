using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchase
    {
        public DateTime PurchaseTime { get; set; }

        public string TariffName { get; set; }

        public decimal TariffPrice { get; set; }
        public string TariffZone { get; set; }
        public double Summ { get; set; }

        public Purchase(DateTime purchaseTime, string tariffName, decimal tariffPrice, string tariffZone, double summ)
        {
            PurchaseTime = purchaseTime;
            TariffName = tariffName;
            TariffPrice = tariffPrice;
            TariffZone = tariffZone;
            Summ = summ;
        }
    }
}
