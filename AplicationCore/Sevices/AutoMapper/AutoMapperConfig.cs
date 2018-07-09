using AplicationCore.Entities;
using AplicationCore.Sevices.Dtos;
using AutoMapper;

namespace AplicationCore.Sevices.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Address, AddressDto>().ReverseMap();
                cfg.CreateMap<Person, PersonDto>().ReverseMap();
                cfg.CreateMap<RecordFilter, RecordFilterDto>().ReverseMap();
                cfg.CreateMap<TypeResidencialProperty, TypeResidencialPropertyDto>().ReverseMap();
                cfg.CreateMap<ResidencialProperty, ResidencialPropertyDto>().ReverseMap();
                cfg.CreateMap<Favorite, FavoriteDto>().ReverseMap();
            });
        }
    }
}
