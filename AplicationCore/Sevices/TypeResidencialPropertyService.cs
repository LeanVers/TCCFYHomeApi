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
    public interface ITypeResidencialPropertyService
    {
        Task<TypeResidencialPropertyDto> AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialProperty);
        Task<IEnumerable<TypeResidencialPropertyDto>> GetAllTypeResidencialProperty();
        Task<TypeResidencialPropertyDto> UpdateTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialPropertyDto);
        Task<TypeResidencialPropertyDto> GetTypeResidencialProperty(int typeResidencialPropertyId);
    }

    public class TypeResidencialPropertyService : ITypeResidencialPropertyService
    {
        private readonly IRepository<TypeResidencialProperty> _typeResidencialPropertyRepository;
        private readonly IAsyncRepository<TypeResidencialProperty> _asyncTypeResidencialPropertyRepository;
        private readonly IAppLogger<TypeResidencialPropertyService> _logger;
        private TypeResidencialProperty _typeResidencialProperty;

        public TypeResidencialPropertyService(IRepository<TypeResidencialProperty> typeResidencialPropertyRepository,
            IAsyncRepository<TypeResidencialProperty> typeResidencialPropertyAsyncRepository,
            IAppLogger<TypeResidencialPropertyService> logger
            )
        {
            _typeResidencialPropertyRepository = typeResidencialPropertyRepository;
            _logger = logger;
            _asyncTypeResidencialPropertyRepository = typeResidencialPropertyAsyncRepository;
        }

        public async Task<TypeResidencialPropertyDto> AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            var typeResidencialProperty = Mapper.Map<TypeResidencialProperty>(typeResidencialPropertyDto);

            typeResidencialProperty.SetValuesBase();

            this._typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.AddAsync(typeResidencialProperty);

            return Mapper.Map<TypeResidencialPropertyDto>(this._typeResidencialProperty);
        }

        public async Task<IEnumerable<TypeResidencialPropertyDto>> GetAllTypeResidencialProperty()
        {
            var typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<TypeResidencialPropertyDto>>(typeResidencialProperty);
        }

        public async Task<TypeResidencialPropertyDto> GetTypeResidencialProperty(int typeResidencialPropertyId)
        {
            var typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.GetByIdAsync(typeResidencialPropertyId);

            return Mapper.Map<TypeResidencialPropertyDto>(typeResidencialProperty);
        }

        public async Task<TypeResidencialPropertyDto> UpdateTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            try
            {
                var typeResidencialProperty = Mapper.Map<TypeResidencialProperty>(typeResidencialPropertyDto);

                typeResidencialProperty.SetValuesBase();

                await _asyncTypeResidencialPropertyRepository.UpdateAsync(typeResidencialProperty);

                return Mapper.Map<TypeResidencialPropertyDto>(typeResidencialProperty);
            }
            catch
            {
                return null;
            }
        }
    }
}
