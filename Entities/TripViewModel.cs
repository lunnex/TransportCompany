using System;

namespace Entities
{
    public class TripViewModel
    {
        public int TripId { get; set; }
        public string Passenger { get; set;}
        public string DriverFirstName { get; set;}
        public string DriverSecondName { get; set;}
        public string DriverPhotoPath { get; set; }
        public string Route { get; set;}
        public string StockNumber { get; set;}
        public DateTime TripTime { get; set; }
        public int? Mark { get; set; }

        public TripViewModel(int tripId, string passenger, string driverFN, string driverSN, string photo, string route, string stockNumber, DateTime tripTime, int? mark)
        {
            TripId = tripId;
            Passenger = passenger;
            DriverFirstName = driverFN;
            DriverSecondName = driverSN;
            DriverPhotoPath = photo;
            Route = route;
            StockNumber = stockNumber;
            TripTime = tripTime;
            Mark = mark;
        }

        public TripViewModel()
        {

        }
    }
}
