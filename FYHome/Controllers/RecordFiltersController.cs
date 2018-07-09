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
    public class RecordFiltersController : ControllerBase
    {
        private readonly IRecordFilterService _recordFilterService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="recordFilterService"></param>
        public RecordFiltersController(IRecordFilterService recordFilterService)
        {
            _recordFilterService = recordFilterService;
        }

        /// <summary>
        /// Cadastra uma filtro na aplicação
        /// </summary>
        /// <param name="recordFilterDto">Objeto Pessoa</param>
        /// <returns></returns>        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "RecordFilter" })]
        public async Task<IActionResult> PostAsync([FromBody] RecordFilterDto recordFilterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _recordFilterService.AddRecordFilter(recordFilterDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Atualiza dados do Endereço
        /// </summary>
        /// <param name="recordFilterId"></param>
        /// <param name="recordFilterDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "RecordFilter" })]
        public async Task<IActionResult> PutAsync([FromBody] RecordFilterDto recordFilterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _recordFilterService.UpdateRecordFilter(recordFilterDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna todos os filtros cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "RecordFilter" })]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var RecordFilter = await _recordFilterService.GetAllRecordFilter();

                if (RecordFilter == null)
                {
                    return NotFound("Não Encontrado nenhum filtro!");
                }

                return Ok(RecordFilter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna o filtro por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "RecordFilter" })]
        public async Task<IActionResult> GetAsync(int recordFilterId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var RecordFilter = await _recordFilterService.GetRecordFilter(recordFilterId);

                if (RecordFilter == null)
                {
                    return NotFound("Não Encontrado nenhum filtro!");
                }

                return Ok(RecordFilter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}