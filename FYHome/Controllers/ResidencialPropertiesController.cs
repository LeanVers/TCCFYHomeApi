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
    /// <summary>
    /// Controller Residencial Properties
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResidencialPropertiesController : ControllerBase
    {
        private readonly IResidencialPropertyService _residencialPropertyService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="residencialPropertyService"></param>
        public ResidencialPropertiesController(IResidencialPropertyService residencialPropertyService)
        {
            _residencialPropertyService = residencialPropertyService;
        }

        /// <summary>
        /// Cadastra um Imóvel na aplicação
        /// </summary>
        /// <param name="residencialPropertyDto">Objeto Pessoa</param>
        /// <returns></returns>        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "ResidencialProperty" })]
        public async Task<IActionResult> PostAsync([FromBody] ResidencialPropertyDto residencialPropertyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _residencialPropertyService.AddResidencialProperty(residencialPropertyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Atualiza dados do Imóvel
        /// </summary>
        /// <param name="residencialPropertyDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "ResidencialProperty" })]
        public async Task<IActionResult> PutAsync([FromBody] ResidencialPropertyDto residencialPropertyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _residencialPropertyService.UpdateResidencialProperty(residencialPropertyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna todos os Imóveis cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "ResidencialProperty" })]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ResidencialProperty = await _residencialPropertyService.GetAllResidencialProperty();

                if (ResidencialProperty == null)
                {
                    return NotFound("Não Encontrado nenhum Imóvel!");
                }

                return Ok(ResidencialProperty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna o Imóvel por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "ResidencialProperty" })]
        public async Task<IActionResult> GetAsync(int residencialPropertyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ResidencialProperty = await _residencialPropertyService.GetResidencialProperty(residencialPropertyId);

                if (ResidencialProperty == null)
                {
                    return NotFound("Não Encontrado nenhum Imóvel!");
                }

                return Ok(ResidencialProperty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}