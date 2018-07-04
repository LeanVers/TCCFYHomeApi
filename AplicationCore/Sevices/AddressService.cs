using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface IAddressService
    {
        Task<Address> AddAddress(AddressDto address);
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address> UpdateAddress(int addressId, AddressDto addressDto);
        Task<Address> GetAddress(int addressId);
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

        public async Task<Address> AddAddress(AddressDto addressDto)
        {
            this._address = new Address();
            this._address.AddAddress(addressDto);

            this._address = await _asyncAddressRepository.AddAsync(this._address);

            return _address;
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            var people = await _asyncAddressRepository.ListAllAsync();

            return people;
        }

        public async Task<Address> GetAddress(int addressId)
        {
            var Address = await _asyncAddressRepository.GetByIdAsync(addressId);

            return Address;
        }

        public async Task<Address> UpdateAddress(int addressId, AddressDto addressDto)
        {
            try
            {
                this._address = new Address();
                this._address.AddAddress(addressDto, addressId);

                await _asyncAddressRepository.UpdateAsync(_address);

                return _address;
            }
            catch
            {
                return null;
            }
        }
    }
}
