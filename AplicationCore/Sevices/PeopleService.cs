using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicationCore.Sevices
{
    public interface IPeopleService
    {
        Task<PersonDto> AddPerson(PersonDto person);
        Task<IEnumerable<PersonDto>> GetAllPerson();
        Task<PersonDto> UpdatePerson(PersonDto personDto);
        Task<PersonDto> GetPerson(int personId);
    }

    public class PeopleService : IPeopleService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IAsyncRepository<Person> _personAsyncRepository;
        private readonly IAppLogger<PeopleService> _logger;
        private Person _person;

        public PeopleService(IRepository<Person> personRepository,
            IAsyncRepository<Person> personAsyncRepository,
            IAppLogger<PeopleService> logger
            )
        {
            _personRepository = personRepository;
            _logger = logger;
            _personAsyncRepository = personAsyncRepository;
        }

        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            var person = Mapper.Map<Person>(personDto);

            person.SetValuesBase();

            this._person = await _personAsyncRepository.AddAsync(person);

            return Mapper.Map<PersonDto>(this._person);
        }

        public async Task<IEnumerable<PersonDto>> GetAllPerson()
        {
            var people = await _personAsyncRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<PersonDto>>(people);
        }

        public async Task<PersonDto> GetPerson(int personId)
        {
            var person = await _personAsyncRepository.GetByIdAsync(personId);

            return Mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> UpdatePerson(PersonDto personDto)
        {
            try
            {
                var person = Mapper.Map<Person>(personDto);

                person.SetValuesBase();

                await _personAsyncRepository.UpdateAsync(person);

                return Mapper.Map<PersonDto>(person);
            }
            catch
            {
                return null;
            }
        }
    }
}
