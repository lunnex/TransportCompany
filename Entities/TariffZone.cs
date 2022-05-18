using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TariffZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Coefficient { get; set; }

        public TariffZone(int id, string name, string description, double coefficient)
        {
            Id = id;
            Name = name;
            Description = description;
            Coefficient = coefficient;
        }
    }
}
