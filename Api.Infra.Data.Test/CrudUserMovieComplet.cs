
using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Infra.Data.Test
{
    public class CrudUserMovieComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudUserMovieComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "UserMovies CRUD")]
        [Trait("CRUD", "UserMoviesEntity")]
        public async Task It_is_possible_to_perform_User_Movies_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MovieImplementation _movieRepositorio = new MovieImplementation(context);
                MovieEntity _movieEntity = new MovieEntity 
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    GenreId = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                    Description = Faker.Lorem.Paragraph(2)
                };                
                var _movie_record_created = await _movieRepositorio.InsertAsync(_movieEntity);

                UserImplementation _userRepositorio = new UserImplementation(context);
                UserEntity _userEntity = new UserEntity 
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _user_record_created = await _userRepositorio.InsertAsync(_userEntity);

                UserMoviesImplementation _repositorio = new UserMoviesImplementation(context);
                UserMoviesEntity _entity = new UserMoviesEntity 
                {
                    Id = Guid.NewGuid(),
                    MovieId = _movie_record_created.Id,
                    UserId = _user_record_created.Id
                };
                
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.MovieId, _record_created.MovieId);
                Assert.Equal(_entity.UserId, _record_created.UserId);
                Assert.False(_record_created.Id == Guid.NewGuid());

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_movie_name_a = await _repositorio.FindCompleteByMovieName("a");
                var _find_by_movie_name_e = await _repositorio.FindCompleteByMovieName("e");
                var _find_by_movie_name_i = await _repositorio.FindCompleteByMovieName("i");
                var _find_by_movie_name_o = await _repositorio.FindCompleteByMovieName("o");
                Assert.True(
                    _find_by_movie_name_a.Count() > 0 ||
                    _find_by_movie_name_e.Count() > 0 ||
                    _find_by_movie_name_i.Count() > 0 ||
                    _find_by_movie_name_o.Count() > 0
                );

                var _find_by_user_name_a = await _repositorio.FindCompleteByUserName("a");
                var _find_by_user_name_e = await _repositorio.FindCompleteByUserName("e");
                var _find_by_user_name_i = await _repositorio.FindCompleteByUserName("i");
                var _find_by_user_name_o = await _repositorio.FindCompleteByUserName("o");
                Assert.True(
                    _find_by_user_name_a.Count() > 0 ||
                    _find_by_user_name_e.Count() > 0 ||
                    _find_by_user_name_i.Count() > 0 ||
                    _find_by_user_name_o.Count() > 0
                );

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }  
    }
}