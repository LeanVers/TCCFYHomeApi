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
        private readonly IAddressService _addressService;
        private readonly IPeopleService _peopleService;
        private readonly ITypeResidencialPropertyService _typeResidencialPropertyService;


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="residencialPropertyService"></param>
        public ResidencialPropertiesController(IResidencialPropertyService residencialPropertyService,
                                                IAddressService addressService,
                                                IPeopleService peopleService,
                                                ITypeResidencialPropertyService typeResidencialPropertyService)
        {
            _residencialPropertyService = residencialPropertyService;
            _addressService = addressService;
            _peopleService = peopleService;
            _typeResidencialPropertyService = typeResidencialPropertyService;
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


                foreach (var res in ResidencialProperty)
                {                    
                    res.Address = await _addressService.GetAddress(res.AddressId);
                    res.Person = await _peopleService.GetPerson(res.PersonId);
                    res.TypeResidencialProperty = await _typeResidencialPropertyService.GetTypeResidencialProperty(res.TypeResidencialPropertyId);
                }

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
        /// Retorna todos os Imóveis cadastrados pelo usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "ResidencialProperty" })]
        public async Task<IActionResult> GetAllAsyncById(int personId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ResidencialProperty = await _residencialPropertyService.GetAllResidencialProperty(personId);


                foreach (var res in ResidencialProperty)
                {
                    res.Address = await _addressService.GetAddress(res.AddressId);
                    res.Person = await _peopleService.GetPerson(res.PersonId);
                    res.TypeResidencialProperty = await _typeResidencialPropertyService.GetTypeResidencialProperty(res.TypeResidencialPropertyId);
                }

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

                ResidencialProperty.Address = await _addressService.GetAddress(ResidencialProperty.AddressId);
                ResidencialProperty.Person = await _peopleService.GetPerson(ResidencialProperty.PersonId);
                ResidencialProperty.TypeResidencialProperty = await _typeResidencialPropertyService.GetTypeResidencialProperty(ResidencialProperty.TypeResidencialPropertyId);

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