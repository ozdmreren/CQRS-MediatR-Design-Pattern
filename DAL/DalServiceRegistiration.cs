using DAL.CQRS.Handlers.CommandHandlers;
using DAL.CQRS.Handlers.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalServiceRegistiration
    {
        public static void RegisterDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CreateProductCommandHandlers>();
            serviceCollection.AddTransient<DeleteProductCommandHandler>();

            serviceCollection.AddTransient<GetAllProductQueryHandler>();
            serviceCollection.AddTransient<GetByIdProductQueryHandler>();
        }
    }
}
