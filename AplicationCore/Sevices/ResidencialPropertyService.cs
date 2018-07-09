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
    public interface IResidencialPropertyService
    {
        Task<ResidencialPropertyDto> AddResidencialProperty(ResidencialPropertyDto recordFilter);
        Task<IEnumerable<ResidencialPropertyDto>> GetAllResidencialProperty();
        Task<ResidencialPropertyDto> UpdateResidencialProperty(ResidencialPropertyDto recordFilterDto);
        Task<ResidencialPropertyDto> GetResidencialProperty(int recordFilterId);
    }

    public class ResidencialPropertyService : IResidencialPropertyService
    {
        private readonly IRepository<ResidencialProperty> _residencialPropertyRepository;
        private readonly IAsyncRepository<ResidencialProperty> _residencialPropertyAsyncRepository;
        private readonly IAppLogger<PeopleService> _logger;
        private ResidencialProperty _residencialProperty;

        public ResidencialPropertyService(IRepository<ResidencialProperty> residencialPropertyRepository,
            IAsyncRepository<ResidencialProperty> residencialPropertyAsyncRepository,
            IAppLogger<PeopleService> logger
            )
        {
            _residencialPropertyRepository = residencialPropertyRepository;
            _logger = logger;
            _residencialPropertyAsyncRepository = residencialPropertyAsyncRepository;
        }

        public async Task<ResidencialPropertyDto> AddResidencialProperty(ResidencialPropertyDto residencialPropertyDto)
        {
            var residencialProperty = Mapper.Map<ResidencialProperty>(residencialPropertyDto);

            residencialProperty.SetValuesBase();

            this._residencialProperty = await _residencialPropertyAsyncRepository.AddAsync(residencialProperty);

            return Mapper.Map<ResidencialPropertyDto>(this._residencialProperty);
        }

        public async Task<IEnumerable<ResidencialPropertyDto>> GetAllResidencialProperty()
        {
            var people = await _residencialPropertyAsyncRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<ResidencialPropertyDto>>(people);
        }

        public async Task<ResidencialPropertyDto> GetResidencialProperty(int residencialPropertyId)
        {
            var residencialProperty = await _residencialPropertyAsyncRepository.GetByIdAsync(residencialPropertyId);

            return Mapper.Map<ResidencialPropertyDto>(residencialProperty);
        }

        public async Task<ResidencialPropertyDto> UpdateResidencialProperty(ResidencialPropertyDto residencialPropertyDto)
        {
            try
            {
                var residencialProperty = Mapper.Map<ResidencialProperty>(residencialPropertyDto);

                residencialProperty.SetValuesBase();

                await _residencialPropertyAsyncRepository.UpdateAsync(residencialProperty);

                return Mapper.Map<ResidencialPropertyDto>(residencialProperty);
            }
            catch
            {
                return null;
            }
        }
    }
}
