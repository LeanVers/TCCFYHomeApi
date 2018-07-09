using AplicationCore.Sevices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Entities
{
    public class RecordFilter : BaseEntity
    {
        public int RecordFilterId { get; set; }
        public int Rooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal SalePriceMin { get; set; }
        public decimal SalePriceMax { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public string Neighborhood { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}
