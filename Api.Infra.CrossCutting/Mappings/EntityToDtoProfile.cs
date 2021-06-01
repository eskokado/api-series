using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDtoResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}