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
    /// Controller Favorites
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="favoriteService"></param>
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        /// <summary>
        /// Salva um Favorito na aplicação
        /// </summary>
        /// <param name="favoriteDto">Objeto Favorite</param>
        /// <returns></returns>        
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Favorite" })]
        public async Task<IActionResult> PostAsync([FromBody] FavoriteDto favoriteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _favoriteService.AddFavorite(favoriteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Atualiza dados do Favorito
        /// </summary>
        /// <param name="favoriteDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Favorite" })]
        public async Task<IActionResult> PutAsync([FromBody] FavoriteDto favoriteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _favoriteService.UpdateFavorite(favoriteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna todos os Favoritos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Favorite" })]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Favorite = await _favoriteService.GetAllFavorite();

                if (Favorite == null)
                {
                    return NotFound("Não Encontrado nenhum favorito!");
                }

                return Ok(Favorite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna o Favorito por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Favorite" })]
        public async Task<IActionResult> GetAsync(int favoriteId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Favorite = await _favoriteService.GetFavorite(favoriteId);

                if (Favorite == null)
                {
                    return NotFound("Não Encontrado nenhum favorito!");
                }

                return Ok(Favorite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}