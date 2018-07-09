using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicationCore.Sevices.Dtos;
using AplicationCore.Sevices;
using AplicationCore.Entities;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FYHome.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleService"></param>
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        /// <summary>
        /// Cadastra uma pessoa na aplicação
        /// </summary>
        /// <param name="personDto">Objeto Pessoa</param>
        /// <returns></returns>        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "People" })]
        public async Task<IActionResult> PostAsync([FromBody] PersonDto personDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _peopleService.AddPerson(personDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
        
        /// <summary>
        /// Atualiza dados da Pessoa
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="personDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "People" })]
        public async Task<IActionResult> PutAsync([FromBody] PersonDto personDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _peopleService.UpdatePerson(personDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "People" })]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var people = await _peopleService.GetAllPerson();

                if(people == null)
                {
                    return NotFound("Não Encontrada nenhuma Pessoa!");
                }

                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "People" })]
        public async Task<IActionResult> GetAsync(int personId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var people = await _peopleService.GetPerson(personId);

                if (people == null)
                {
                    return NotFound("Não Encontrada nenhuma Pessoa!");
                }

                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}