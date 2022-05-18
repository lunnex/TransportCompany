using Entities;
using System.Collections.Generic;

namespace TransportCompany.Models
{
    public class PurchaseViewModel
    {
        public List<TariffZone> TariffZones { get; set; }
        public Tariff Tariff { get; set; }
        public List<double> Prices { get; set; }

        public PurchaseViewModel(List<TariffZone> tariffZones, Tariff tariff)
        {
            TariffZones = tariffZones;
            Tariff = tariff;
            Prices = new List<double>();
            
            foreach (var zone in tariffZones)
            {
                Prices.Add(System.Math.Round(zone.Coefficient * (double)tariff.Price, 2));
            }
        }
    }

}
