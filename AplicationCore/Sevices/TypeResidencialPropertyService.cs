using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface ITypeResidencialPropertyService
    {
        Task<TypeResidencialProperty> AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialProperty);
        Task<IEnumerable<TypeResidencialProperty>> GetAllTypeResidencialProperty();
        Task<TypeResidencialProperty> UpdateTypeResidencialProperty(int typeResidencialPropertyId, TypeResidencialPropertyDto typeResidencialPropertyDto);
        Task<TypeResidencialProperty> GetTypeResidencialProperty(int typeResidencialPropertyId);
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

        public async Task<TypeResidencialProperty> AddTypeResidencialProperty(TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            this._typeResidencialProperty = new TypeResidencialProperty();
            this._typeResidencialProperty.AddTypeResidencialProperty(typeResidencialPropertyDto);

            this._typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.AddAsync(this._typeResidencialProperty);

            return _typeResidencialProperty;
        }

        public async Task<IEnumerable<TypeResidencialProperty>> GetAllTypeResidencialProperty()
        {
            var typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.ListAllAsync();

            return typeResidencialProperty;
        }

        public async Task<TypeResidencialProperty> GetTypeResidencialProperty(int typeResidencialPropertyId)
        {
            var typeResidencialProperty = await _asyncTypeResidencialPropertyRepository.GetByIdAsync(typeResidencialPropertyId);

            return typeResidencialProperty;
        }

        public async Task<TypeResidencialProperty> UpdateTypeResidencialProperty(int typeResidencialPropertyId, TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            try
            {
                this._typeResidencialProperty = new TypeResidencialProperty();
                this._typeResidencialProperty.AddTypeResidencialProperty(typeResidencialPropertyDto, typeResidencialPropertyId);

                await _asyncTypeResidencialPropertyRepository.UpdateAsync(_typeResidencialProperty);

                return _typeResidencialProperty;
            }
            catch
            {
                return null;
            }
        }
    }
}
