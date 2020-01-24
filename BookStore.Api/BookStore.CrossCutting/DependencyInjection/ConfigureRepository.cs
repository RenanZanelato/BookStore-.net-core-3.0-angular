using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Context;
using BookStore.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenceRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();
            serviceCollection.AddScoped<IGenreRepository, GenreRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;")
                );
        }

    }
}

