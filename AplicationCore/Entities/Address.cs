using System;
using System.Collections.Generic;
using System.Text;
using AplicationCore.Sevices.Dtos;

namespace AplicationCore.Entities
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string UF { get; set; }
        public string AdditionalInfo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }        
    }
}
