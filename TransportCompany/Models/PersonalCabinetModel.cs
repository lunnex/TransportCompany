using Entities;
using System.Collections.Generic;

namespace TransportCompany.Models
{
    public class PersonalCabinetModel
    {
        public Passenger Passenger { get; set; }
        public Tariff Tariff { get; set; }
        public Ticket Ticket { get; set; }
        public List<TripViewModel> Trips { get; set; }
        
        public PersonalCabinetModel(Passenger passenger, Tariff tariff, Ticket ticket, List<TripViewModel> trips)
        {
            Passenger = passenger;
            Tariff = tariff;
            Ticket = ticket;
            Trips = trips;
        }

        public PersonalCabinetModel()
        {

        }
    }
}
