﻿using System;
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
        private readonly IResidencialPropertyService _residencialPropertyService;
        private readonly IAddressService _addressService;
        private readonly IPeopleService _peopleService;
        private readonly ITypeResidencialPropertyService _typeResidencialPropertyService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="favoriteService"></param>
        public FavoritesController(IFavoriteService favoriteService, 
                                    IResidencialPropertyService residencialPropertyService,
                                    IAddressService addressService,
                                    IPeopleService peopleService,
                                    ITypeResidencialPropertyService typeResidencialPropertyService)
        {
            _favoriteService = favoriteService;
            _residencialPropertyService = residencialPropertyService;
            _addressService = addressService;
            _peopleService = peopleService;
            _typeResidencialPropertyService = typeResidencialPropertyService;
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

                foreach (var res in Favorite)
                {
                    res.ResidecialProperty = await _residencialPropertyService.GetResidencialProperty(res.ResidencialPropertyId);
                    res.ResidecialProperty.Address = await _addressService.GetAddress(res.ResidecialProperty.AddressId);
                    res.ResidecialProperty.Person = await _peopleService.GetPerson(res.ResidecialProperty.PersonId);
                    res.ResidecialProperty.TypeResidencialProperty = await _typeResidencialPropertyService.GetTypeResidencialProperty(res.ResidecialProperty.TypeResidencialPropertyId);
                    res.Person = await _peopleService.GetPerson(res.PersonID);
                }

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