using Api.Domain.Dtos;
using Api.Domain.Dtos.Genre;
using Api.Domain.Dtos.Movie;
using Api.Domain.Dtos.UserMovies;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDtoResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            #endregion

            #region Genre
            CreateMap<GenreDtoResult, GenreEntity>().ReverseMap();

            CreateMap<GenreDtoCreateResult, GenreEntity>().ReverseMap();

            CreateMap<GenreDtoUpdateResult, GenreEntity>().ReverseMap();
            #endregion

            #region Movie
            CreateMap<MovieDtoResult, MovieEntity>().ReverseMap();

            CreateMap<MovieDtoCreateResult, MovieEntity>().ReverseMap();

            CreateMap<MovieDtoUpdateResult, MovieEntity>().ReverseMap();
            #endregion

            #region UserMovies
            CreateMap<UserMoviesDtoResult, UserMoviesEntity>().ReverseMap();
            #endregion
        }
    }
}