using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Api.Domain.Dtos.Movie;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Movie
{
    public class WhenToRequestMovie : BaseIntegration
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private Guid _genreId { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunMovieCrud() {
            await AddToken();
            // Find By Name
            var responseGenre = await client.GetAsync($"{hostApi}/genres/findByName/av");
            Assert.Equal(HttpStatusCode.OK, responseGenre.StatusCode);

            var jsonResultGenre = await responseGenre.Content.ReadAsStringAsync();
            var listFromJsonGenre = JsonConvert.DeserializeObject<IEnumerable<GenreDtoResult>>(jsonResultGenre);
            var recordSelectedGenre = listFromJsonGenre.FirstOrDefault();

            _name = Faker.Name.FullName();
            _description = Faker.Lorem.Sentence(25);
            _genreId = recordSelectedGenre.Id;

            var movieDto = new MovieDtoCreate()
            {
                Name = _name,
                Description = _description,
                GenreId = _genreId
            };

            // Post
            var response = await PostJsonAsync(movieDto, $"{hostApi}/movies", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<MovieDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.Equal(_description, recordPost.Description);
            Assert.Equal(_genreId, recordPost.GenreId);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/movies");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<MovieDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Find By Name
            response = await client.GetAsync($"{hostApi}/movies/findByName/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<MovieDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Find By Descritpion
            response = await client.GetAsync($"{hostApi}/movies/findByDescription/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<MovieDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Find By Name or Descritpion
            response = await client.GetAsync($"{hostApi}/movies/findByNameOrDescription/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<MovieDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Find By Genre Name
            response = await client.GetAsync($"{hostApi}/movies/findByGenreName/av");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<MovieDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Put
            var updateMovieDto = new MovieDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentence(25),
                GenreId = recordSelectedGenre.Id
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateMovieDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/movies", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<MovieDtoUpdateResult>(jsonResult);

            Assert.Equal(updateMovieDto.Id, recordUpdate.Id);
            Assert.Equal(updateMovieDto.Name, recordUpdate.Name);
            Assert.Equal(updateMovieDto.Description, recordUpdate.Description);
            Assert.Equal(updateMovieDto.GenreId, recordUpdate.GenreId);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/movies/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<MovieDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);
            Assert.Equal(recordSelected.Description, recordUpdate.Description);
            Assert.Equal(recordSelected.GenreId, recordUpdate.GenreId);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/movies/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/movies/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}