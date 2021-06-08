using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Genre;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Genre
{
    public class WhenToRequestGenre : BaseIntegration
    {
        private string _name { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunGenreCrud() {
            await AddToken();
            _name = Faker.Name.First();

            var genreDto = new GenreDtoCreate()
            {
                Name = _name,
            };

            // Post
            var response = await PostJsonAsync(genreDto, $"{hostApi}/genres", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<GenreDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/genres");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<GenreDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Find By Name
            response = await client.GetAsync($"{hostApi}/genres/findByName/av");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<GenreDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Put
            var updateGenreDto = new GenreDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Name.FullName(),
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateGenreDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/genres", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<GenreDtoUpdateResult>(jsonResult);

            Assert.Equal(updateGenreDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Name, recordUpdate.Name);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/genres/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<GenreDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/genres/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/genres/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}