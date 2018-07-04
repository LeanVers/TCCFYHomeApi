using AplicationCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Sevices.Dtos
{
    public class RecordFilterDto
    {
        [JsonIgnore]
        public int RecordFilterId { get; set; }
        public int Rooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal SalePriceMin { get; set; }
        public decimal SalePriceMax { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public string Neighborhood { get; set; }        
        public Person Person { get; set; }
    }
}
