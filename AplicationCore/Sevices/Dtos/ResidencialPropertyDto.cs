using System;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Sevices.Dtos
{
    public class ResidencialPropertyDto
    {
        public int ResidencialPropertyId { get; set; }
        public int Rooms { get; set; }
        public int ParkingSpaces { get; set; }
        public decimal Area { get; set; }
        public string AdditionalInfo { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public int TypeResidencialPropertyId { get; set; }
        public int PersonId { get; set; }
    }
}
