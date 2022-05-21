using System;

namespace Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int IdWaybill { get; set; }
        public int IdTicket { get; set; }
        public DateTime TripTime { get; set; }
        public int? Mark { get; set; }

        public Trip(int id, int idWaybill, int idTicket, DateTime tripTime, int? mark)
        {
            Id = id;
            IdWaybill = idWaybill;
            IdTicket = idTicket;
            TripTime = tripTime;
            Mark = mark;
        }
    }
}
