using Api.Domain.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IGenreRepository, GenreImplementation>();
            serviceCollection.AddScoped<IMovieRepository, MovieImplementation>();
            serviceCollection.AddScoped<IUserMoviesRepository, UserMoviesImplementation>();
            
            var connectionString = 
                "Server=localhost;Port=3306;Database=dbApiSeries;Uid=root;Pwd=root";

            // var connectionString =
            //     "Server=(localdb)\\mssqllocaldb;Database=dbApiSeries;Trusted_Connection=True;MultipleActiveResultSets=true;user=sa;password=sa@123456";

            serviceCollection.AddDbContext<MyContext> (
                options => 
                
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                // options
                //     .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbApiSeries;Trusted_Connection=True;MultipleActiveResultSets=true;user=sa;password=sa@123456")
            );
        }        
    }
}