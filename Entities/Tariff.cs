using System;

namespace Entities
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? ValidityPeriod { get; set; }
        public string Description { get; set; }
        public int? TripCount { get; set; }

        public Tariff(int id, string name, decimal price, int? validityPeriod, string description, int? tripCount)
        {
            Id = id;
            Name = name;
            Price = price;
            ValidityPeriod = validityPeriod;
            Description = description;
            TripCount = tripCount;
        }
    }
}
