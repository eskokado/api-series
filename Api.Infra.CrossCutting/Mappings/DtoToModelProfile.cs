using Api.Domain.Dtos;
using Api.Domain.Dtos.Genre;
using Api.Domain.Dtos.Movie;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
            CreateMap<GenreModel, GenreDtoCreate>()
                .ReverseMap();
            CreateMap<GenreModel, GenreDtoUpdate>()
                .ReverseMap();
            CreateMap<MovieModel, MovieDtoCreate>()
                .ReverseMap();
            CreateMap<MovieModel, MovieDtoUpdate>()
                .ReverseMap();
            CreateMap<UserMoviesModel, UserMoviesDtoCreate>()
                .ReverseMap();
            CreateMap<UserMoviesModel, UserMoviesDtoUpdate>()
                .ReverseMap();
        }
    }
}