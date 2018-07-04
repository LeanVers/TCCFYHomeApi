using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Sevices.Dtos
{
    public class AddressDto
    {
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
