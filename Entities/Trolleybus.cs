using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Trolleybus : Stock
    {
        public string ControlType { get; set; }

        public Trolleybus(string regNum, int year, string manufacturer, string photo, string controlType) : base(regNum, year, manufacturer, photo)
        {
            ControlType = controlType;
        }
    }
}
