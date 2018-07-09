using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface IRecordFilterService
    {
        Task<RecordFilterDto> AddRecordFilter(RecordFilterDto recordFilter);
        Task<IEnumerable<RecordFilterDto>> GetAllRecordFilter();
        Task<RecordFilterDto> UpdateRecordFilter(RecordFilterDto recordFilterDto);
        Task<RecordFilterDto> GetRecordFilter(int recordFilterId);
    }

    public class RecordFilterService : IRecordFilterService
    {
        private readonly IRepository<RecordFilter> _RecordFilterRepository;
        private readonly IAsyncRepository<RecordFilter> _recordFilterAsyncRepository;
        private readonly IAppLogger<PeopleService> _logger;
        private RecordFilter _recordFilter;

        public RecordFilterService(IRepository<RecordFilter> recordFilterRepository,
            IAsyncRepository<RecordFilter> recordAsyncFilterRepository,
            IAppLogger<PeopleService> logger
            )
        {
            _RecordFilterRepository = recordFilterRepository;
            _logger = logger;
            _recordFilterAsyncRepository = recordAsyncFilterRepository;
        }

        public async Task<RecordFilterDto> AddRecordFilter(RecordFilterDto recordFilterDto)
        {
            var recordFilter = Mapper.Map<RecordFilter>(recordFilterDto);

            recordFilter.SetValuesBase();

            this._recordFilter = await _recordFilterAsyncRepository.AddAsync(recordFilter);

            return Mapper.Map<RecordFilterDto>(this._recordFilter);
        }

        public async Task<IEnumerable<RecordFilterDto>> GetAllRecordFilter()
        {
            var recordFilter = await _recordFilterAsyncRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<RecordFilterDto>>(recordFilter);
        }

        public async Task<RecordFilterDto> GetRecordFilter(int recordFilterId)
        {
            var RecordFilter = await _recordFilterAsyncRepository.GetByIdAsync(recordFilterId);

            return Mapper.Map<RecordFilterDto>(RecordFilter);
        }

        public async Task<RecordFilterDto> UpdateRecordFilter(RecordFilterDto recordFilterDto)
        {
            try
            {
                var recordFilter = Mapper.Map<RecordFilter>(recordFilterDto);

                recordFilter.SetValuesBase();

                await _recordFilterAsyncRepository.UpdateAsync(recordFilter);

                return Mapper.Map<RecordFilterDto>(recordFilter);
            }
            catch
            {
                return null;
            }
        }
    }
}
