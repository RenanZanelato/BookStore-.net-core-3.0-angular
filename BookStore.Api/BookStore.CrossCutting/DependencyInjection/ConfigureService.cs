using BookStore.Domain.Interfaces.Service;
using BookStore.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenceService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            serviceCollection.AddTransient<IBookService, BookService>();
            serviceCollection.AddTransient<IAuthorService, AuthorService>();
        }
    }
}
