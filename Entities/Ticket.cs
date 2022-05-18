using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string PhonePassenger { get; set; }
        public int IdTariff { get; set; }
        public int IdTariffZone { get; set; }
        public DateTime? Expiration { get; set; }
        public int? TripRemains { get; set; }
        public DateTime PurchaseTime { get; set; }

        public Ticket(int id, string phonePassenger, int idTariff, int idTariffZone, DateTime purchaseTime, DateTime? expiration = null, int? tripRemains = null)
        {
            Id = id;
            PhonePassenger = phonePassenger;
            IdTariff = idTariff;
            IdTariffZone = idTariffZone;
            Expiration = expiration;
            TripRemains = tripRemains;
            PurchaseTime = purchaseTime;
        }
    }
}
