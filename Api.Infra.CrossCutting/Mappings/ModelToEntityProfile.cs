using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<GenreEntity, GenreModel>().ReverseMap();
            CreateMap<MovieEntity, MovieModel>().ReverseMap();
            CreateMap<UserMoviesEntity, UserMoviesModel>().ReverseMap();
        }
    }
}