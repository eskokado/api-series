
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
    public class CrudMovieComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudMovieComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Movie CRUD")]
        [Trait("CRUD", "MovieEntity")]
        public async Task It_is_possible_to_perform_Movie_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MovieImplementation _repositorio = new MovieImplementation(context);
                MovieEntity _entity = new MovieEntity 
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    GenreId = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                    Description = Faker.Lorem.Paragraph(2)
                };
                
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.Name, _record_created.Name);
                Assert.False(_record_created.Id == Guid.NewGuid());

                _entity = _record_created;
                _entity.Name = Faker.Name.First();

                var _record_update = await _repositorio.UpdateAsync(_entity);
                Assert.Equal(_entity, _record_update);
                Assert.True(_record_update.Id == _entity.Id);

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_description = await _repositorio.FindCompleteByDescription("a");
                Assert.True(_find_by_description.Count() > 0);

                var _find_by_name_description = await _repositorio.FindCompleteByNameAndDescription("a");
                Assert.True(_find_by_name_description.Count() > 0);

                var _find_by_name = await _repositorio.FindCompleteByName("a");
                Assert.True(_find_by_name.Count() > 0);

                var _find_by_genre_name = await _repositorio.FindCompleteByGenreName("ma");
                Assert.True(_find_by_genre_name.Count() > 0);

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }  
    }
}