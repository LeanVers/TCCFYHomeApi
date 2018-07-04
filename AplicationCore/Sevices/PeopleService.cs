using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicationCore.Sevices
{
    public interface IPeopleService
    {
        Task<Person> AddPerson(PersonDto person);
        Task<IEnumerable<Person>> GetAllPerson();
        Task<Person> UpdatePerson(int personId, PersonDto personDto);
        Task<Person> GetPerson(int personId);
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

        public async Task<Person> AddPerson(PersonDto personDto)
        {
            this._person = new Person();
            this._person.AddPerson(personDto);

            this._person = await _personAsyncRepository.AddAsync(this._person);

            return _person;
        }

        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            var people = await _personAsyncRepository.ListAllAsync();

            return people;
        }

        public async Task<Person> GetPerson(int personId)
        {
            var person = await _personAsyncRepository.GetByIdAsync(personId);

            return person;
        }

        public async Task<Person> UpdatePerson(int personId, PersonDto personDto)
        {
            try
            {
                this._person = new Person();
                this._person.AddPerson(personDto, personId);

                await _personAsyncRepository.UpdateAsync(_person);

                return _person;
            }
            catch
            {
                return null;
            }
        }
    }
}
