using CatalogService.Application.Intercfaces.Repositories;
using CatalogService.Infrastructure.Context;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure.Extensions
{
    public static class DbContextRegistiration
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            });

            serviceCollection.AddScoped<ICatalogRepository, CatalogRepository>();

            DbContextOptionsBuilder<CatalogDbContext> optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>().UseSqlServer(configuration.GetConnectionString("SQLServer"));
            CatalogDbContext dbContext = new CatalogDbContext(optionsBuilder.Options, null);
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return serviceCollection;
        }
    }
}
