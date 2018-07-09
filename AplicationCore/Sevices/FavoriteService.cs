using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Sevices.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Sevices
{
    public interface IFavoriteService
    {
        Task<FavoriteDto> AddFavorite(FavoriteDto favorite);
        Task<IEnumerable<FavoriteDto>> GetAllFavorite();
        Task<FavoriteDto> UpdateFavorite(FavoriteDto favoriteDto);
        Task<FavoriteDto> GetFavorite(int favoriteId);
    }

    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> _favoriteRepository;
        private readonly IAsyncRepository<Favorite> _asyncFavoriteRepository;
        private readonly IAppLogger<PeopleService> _logger;
        private Favorite _favorite;

        public FavoriteService(IRepository<Favorite> favoriteRepository,
            IAsyncRepository<Favorite> favoriteAsyncRepository,
            IAppLogger<PeopleService> logger
            )
        {
            _favoriteRepository = favoriteRepository;
            _logger = logger;
            _asyncFavoriteRepository = favoriteAsyncRepository;
        }

        public async Task<FavoriteDto> AddFavorite(FavoriteDto favoriteDto)
        {
            var favorite = Mapper.Map<Favorite>(favoriteDto);

            favorite.SetValuesBase();

            this._favorite = await _asyncFavoriteRepository.AddAsync(favorite);

            return Mapper.Map<FavoriteDto>(this._favorite);
        }

        public async Task<IEnumerable<FavoriteDto>> GetAllFavorite()
        {
            var people = await _asyncFavoriteRepository.ListAllAsync();

            return Mapper.Map<IEnumerable<FavoriteDto>>(people);
        }

        public async Task<FavoriteDto> GetFavorite(int favoriteId)
        {
            var Favorite = await _asyncFavoriteRepository.GetByIdAsync(favoriteId);

            return Mapper.Map<FavoriteDto>(Favorite);
        }

        public async Task<FavoriteDto> UpdateFavorite(FavoriteDto favoriteDto)
        {
            try
            {
                var favorite = Mapper.Map<Favorite>(favoriteDto);

                favorite.SetValuesBase();

                await _asyncFavoriteRepository.UpdateAsync(favorite);

                return Mapper.Map<FavoriteDto>(favorite);
            }
            catch
            {
                return null;
            }
        }
    }
}
