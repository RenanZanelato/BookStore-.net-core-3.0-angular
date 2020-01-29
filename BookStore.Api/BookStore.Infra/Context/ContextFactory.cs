using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            return new MyContext(getOptionBuilder(string.IsNullOrEmpty(EnvironmentConnection.ConnectionString)).Options);
        }

        private static DbContextOptionsBuilder<MyContext> getOptionBuilder(bool isdev)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            if (isdev == true)
            {
                optionsBuilder.UseInMemoryDatabase(EnvironmentConnection.DatabaseName);
            }
            return (isdev == true) ? optionsBuilder.UseInMemoryDatabase(EnvironmentConnection.DatabaseName) : optionsBuilder.UseSqlServer(EnvironmentConnection.ConnectionString);

        }

    }
}