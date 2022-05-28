using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bus : Stock
    {
        public double Volume { get; set; }

        public Bus(string regNum, int year, string manufacturer, string photo, double volume) :base(regNum, year, manufacturer, photo)
        {
            Volume = volume;
        }
    }

    
}
