using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stock
    {
        public string RegNum { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Photo { get; set; }

        public Stock(string regNum, int year, string manufacturer, string photo)
        {
            RegNum = regNum;
            Year = year;
            Manufacturer = manufacturer;
            Photo = photo;
        }
    }
}
