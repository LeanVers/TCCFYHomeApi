using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface IAddressService
    {
        Task<AddressDto> AddAddress(AddressDto address);
        Task<IEnumerable<AddressDto>> GetAllAddress();
        Task<AddressDto> UpdateAddress(AddressDto addressDto);
        Task<AddressDto> GetAddress(int addressId);
    }

    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IAsyncRepository<Address> _asyncAddressRepository;
        private readonly IAppLogger<PeopleService> _logger;
        private Address _address;

        public AddressService(IRepository<Address> addressRepository,
            IAsyncRepository<Address> addressAsyncRepository,
            IAppLogger<PeopleService> logger
            )
        {
            _addressRepository = addressRepository;
            _logger = logger;
            _asyncAddressRepository = addressAsyncRepository;
        }

        public async Task<AddressDto> AddAddress(AddressDto addressDto)
        {
            var address = Mapper.Map<Address>(addressDto);

            address.SetValuesBase();

            this._address = await _asyncAddressRepository.AddAsync(address);

            return Mapper.Map<AddressDto>(this._address);
        }

        public async Task<IEnumerable<AddressDto>> GetAllAddress()
        {
            var people = await _asyncAddressRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<AddressDto>>(people);
        }

        public async Task<AddressDto> GetAddress(int addressId)
        {
            var Address = await _asyncAddressRepository.GetByIdAsync(addressId);

            return Mapper.Map<AddressDto>(Address);
        }

        public async Task<AddressDto> UpdateAddress(AddressDto addressDto)
        {
            try
            {
                var address = Mapper.Map<Address>(addressDto);

                address.SetValuesBase();

                await _asyncAddressRepository.UpdateAsync(address);

                return Mapper.Map<AddressDto>(address);
            }
            catch
            {
                return null;
            }
        }
    }
}
