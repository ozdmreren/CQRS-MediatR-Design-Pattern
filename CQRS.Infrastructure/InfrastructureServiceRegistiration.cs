using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Infrastructure
{
    public static class InfrastructureServiceRegistiration
    {
        public static void RegisterInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost; Initial Catalog=product;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            });
        }
    }
}
