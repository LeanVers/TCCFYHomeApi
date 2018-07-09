using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicationCore.Sevices;
using AplicationCore.Sevices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FYHome.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TypesResidencialPropertyController : ControllerBase
    {
        private readonly ITypeResidencialPropertyService _typeResidencialPropertyService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="peopleService"></param>
        public TypesResidencialPropertyController(ITypeResidencialPropertyService peopleService)
        {
            _typeResidencialPropertyService = peopleService;
        }

        /// <summary>
        /// Cadastra um tipo de Imóvel
        /// </summary>
        /// <param name="typeResidencialPropertyDto">Objeto Pessoa</param>
        /// <returns></returns>        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "TypeResidencialProperty" })]
        public async Task<IActionResult> PostAsync([FromBody] TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _typeResidencialPropertyService.AddTypeResidencialProperty(typeResidencialPropertyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
        
        /// <summary>
        /// Atualiza dados do Tipo de Imóvel
        /// </summary>
        /// <param name="typeResidencialPropertyId"></param>
        /// <param name="typeResidencialPropertyDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "TypeResidencialProperty" })]
        public async Task<IActionResult> PutAsync([FromBody] TypeResidencialPropertyDto typeResidencialPropertyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _typeResidencialPropertyService.UpdateTypeResidencialProperty(typeResidencialPropertyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna todos os Tipos de Imóvel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "TypeResidencialProperty" })]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var people = await _typeResidencialPropertyService.GetAllTypeResidencialProperty();

                if(people == null)
                {
                    return NotFound("Não Encontrado nenhum tipo de Imóvel!");
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
        [SwaggerOperation(Tags = new[] { "TypeResidencialProperty" })]
        public async Task<IActionResult> GetAsync(int typeResidencialPropertyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var people = await _typeResidencialPropertyService.GetTypeResidencialProperty(typeResidencialPropertyId);

                if (people == null)
                {
                    return NotFound("Não Encontrado nenhum tipo de Imóvel!");
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