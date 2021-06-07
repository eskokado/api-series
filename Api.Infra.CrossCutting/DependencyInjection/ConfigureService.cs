using Api.Domain.Services;
using Api.Domain.Services.Genre;
using Api.Domain.Services.Movie;
using Api.Domain.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IGenreService, GenreService>();
            serviceCollection.AddTransient<IMovieService, MovieService>();
            serviceCollection.AddTransient<IUserMoviesService, UserMoviesService>();
        }
    }
}