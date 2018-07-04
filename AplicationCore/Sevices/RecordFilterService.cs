using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface IRecordFilterService
    {
        Task<RecordFilter> AddRecordFilter(RecordFilterDto recordFilter);
        Task<IEnumerable<RecordFilter>> GetAllRecordFilter();
        Task<RecordFilter> UpdateRecordFilter(int recordFilterId, RecordFilterDto recordFilterDto);
        Task<RecordFilter> GetRecordFilter(int recordFilterId);
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

        public async Task<RecordFilter> AddRecordFilter(RecordFilterDto recordFilterDto)
        {
            this._recordFilter = new RecordFilter();
            this._recordFilter.AddRecordFilter(recordFilterDto);

            this._recordFilter = await _recordFilterAsyncRepository.AddAsync(this._recordFilter);

            return _recordFilter;
        }

        public async Task<IEnumerable<RecordFilter>> GetAllRecordFilter()
        {
            var people = await _recordFilterAsyncRepository.ListAllAsync();

            return people;
        }

        public async Task<RecordFilter> GetRecordFilter(int recordFilterId)
        {
            var RecordFilter = await _recordFilterAsyncRepository.GetByIdAsync(recordFilterId);

            return RecordFilter;
        }

        public async Task<RecordFilter> UpdateRecordFilter(int recordFilterId, RecordFilterDto recordFilterDto)
        {
            try
            {
                this._recordFilter = new RecordFilter();
                this._recordFilter.AddRecordFilter(recordFilterDto, recordFilterId);

                await _recordFilterAsyncRepository.UpdateAsync(_recordFilter);

                return _recordFilter;
            }
            catch
            {
                return null;
            }
        }
    }
}
