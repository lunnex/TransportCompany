using Entities;
using System.Collections.Generic;

namespace TransportCompany.Models
{
    public class StockModel
    {
        public List<Bus> Buses { get; set; }
        public List<Trolleybus> Trolleybuses { get; set; }

        public StockModel(List<Bus> buses, List<Trolleybus> trolleybuses)
        {
            Buses = buses;
            Trolleybuses = trolleybuses;
        }

        public StockModel(Bus bus, Trolleybus trolleybus)
        {
            Buses = new List<Bus> { bus };
            Trolleybuses = new List<Trolleybus> { trolleybus };
        }

        public StockModel()
        {

        }
    }
}
