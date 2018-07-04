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

        internal void AddAddress(AddressDto addressDto)
        {
            if(addressDto != null)
            {
                this.CEP = addressDto.CEP;
                this.Street = addressDto.Street;
                this.Number = addressDto.Number;
                this.Neighborhood = addressDto.Neighborhood;
                this.City = addressDto.City;
                this.State = addressDto.State;
                this.Country = addressDto.Country;
                this.UF = addressDto.UF;
                this.AdditionalInfo = addressDto.AdditionalInfo;
                this.Latitude = addressDto.Latitude;
                this.Longitude = addressDto.Longitude;
                this.RecordDate = DateTime.Now;
                this.Active = true;
            }
        }

        public void AddAddress(AddressDto addressDto, int AddressId)
        {
            if (addressDto != null)
            {
                this.AddressId = AddressId;
                AddAddress(addressDto);
            }
        }
    }
}
