using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Genre;
using Api.Domain.Dtos.Movie;
using Api.Domain.Dtos.UserMovies;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.UserMovies
{
    public class WhenToRequestUserMovies : BaseIntegration
    {
        private Guid _movieId { get; set; }
        private Guid _userId { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunUserMoviesCrud() {
            await AddToken();

            // Find By Name
            var responseGenre = await client.GetAsync($"{hostApi}/genres/findByName/fi");
            Assert.Equal(HttpStatusCode.OK, responseGenre.StatusCode);

            var jsonResultGenre = await responseGenre.Content.ReadAsStringAsync();
            var listFromJsonGenre = JsonConvert.DeserializeObject<IEnumerable<GenreDtoResult>>(jsonResultGenre);
            var recordSelectedGenre = listFromJsonGenre.FirstOrDefault();

            // Add Movie 
            var _nameMovie = Faker.Name.FullName();
            var _descriptionMovie = Faker.Lorem.Sentence(25);
            var _genreIdMovie = recordSelectedGenre.Id;

            var movieDto = new MovieDtoCreate()
            {
                Name = _nameMovie,
                Description = _descriptionMovie,
                GenreId = _genreIdMovie
            };
            
            // Post Movie
            var responseMovie = await PostJsonAsync(movieDto, $"{hostApi}/movies", client);
            Assert.Equal(HttpStatusCode.Created, responseMovie.StatusCode);
            var postResultMovie = await responseMovie.Content.ReadAsStringAsync();
            var recordPostMovie = JsonConvert.DeserializeObject<MovieDtoCreateResult>(postResultMovie);

            // Find By Name
            var responseUser = await client.GetAsync($"{hostApi}/users/findByName/user");
            Assert.Equal(HttpStatusCode.OK, responseUser.StatusCode);

            var jsonResultUser = await responseUser.Content.ReadAsStringAsync();
            var listFromJsonUser = JsonConvert.DeserializeObject<IEnumerable<UserDtoResult>>(jsonResultUser);
            var recordSelectedUser = listFromJsonUser.FirstOrDefault();

            _movieId = recordPostMovie.Id;
            _userId = recordSelectedUser.Id;

            var userMoviesDto = new UserMoviesDtoCreate()
            {
                MovieId = _movieId,
                UserId = _userId,
            };

            // Post
            var response = await PostJsonAsync(userMoviesDto, $"{hostApi}/userMovies", client);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<UserMoviesDtoResult>(postResult);

            Assert.Equal(_movieId, recordPost.MovieId);
            Assert.Equal(_userId, recordPost.UserId);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/userMovies");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserMoviesDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Find By Movie Name
            response = await client.GetAsync($"{hostApi}/userMovies/findByMovieName/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserMoviesDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Find By User Name
            response = await client.GetAsync($"{hostApi}/userMovies/findByUserName/us");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserMoviesDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Put
            var updateUserMoviesDto = new UserMoviesDtoUpdate()
            {
                Id = recordPost.Id,
                MovieId = _movieId,
                UserId = _userId,
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserMoviesDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/userMovies", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<UserMoviesDtoResult>(jsonResult);

            Assert.Equal(updateUserMoviesDto.Id, recordUpdate.Id);
            Assert.Equal(updateUserMoviesDto.MovieId, recordUpdate.MovieId);
            Assert.Equal(updateUserMoviesDto.UserId, recordUpdate.UserId);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/userMovies/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<UserMoviesDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.MovieId, recordUpdate.MovieId);
            Assert.Equal(recordSelected.UserId, recordUpdate.UserId);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/userMovies/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/userMovies/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}