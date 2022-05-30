using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Waybill
    {
        public string RegNum { get; set; }
        public string RouteNum { get; set; }
        public string DriverName { get; set; }
        public string DriverSecondName { get; set; }
        public DateTime BeginTime { get; set; }

        public Waybill(string regNum, string routeNum, string driverName, string driverStringRoute, DateTime date)
        {
            RegNum = regNum;
            RouteNum = routeNum;
            DriverName = driverName;
            DriverSecondName = driverStringRoute;
            BeginTime = date;
        }
    }
}
