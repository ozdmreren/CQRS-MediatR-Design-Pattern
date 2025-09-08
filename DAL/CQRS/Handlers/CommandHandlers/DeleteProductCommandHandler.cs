using CQRS.Domain.AggregateModels.ProductAggregate;
using CQRS.Infrastructure.Context;
using DAL.CQRS.Commands.Request;
using DAL.CQRS.Commands.Response;

namespace DAL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        private readonly ProductDbContext context;
        public DeleteProductCommandHandler(ProductDbContext context)
        {
            this.context = context;
        }
        public DeleteProductCommandResponse DeleteProduct(DeleteProductCommandRequest request)
        {
            Product? exists = context.Products.Find(request.Id);

            if (exists is null) throw new NullReferenceException("There is no such a record");

            // context.Database.EnsureCreated(); // Her zaman otomatik olarak migration işlemini gerçekleştirir. Avantajlıdır çünkü hızlıdır. Dezavantajlıdır çünkü migrationun bir tarihi olmadığı için farklı migrationlarda sıkıntılar çıkabilir.
            // context.Database.Migrate(); // Migration varsa migrate etme işlemini gerçekleştirir.

            context.Products.Remove(exists);

            context.SaveChanges();

            return new DeleteProductCommandResponse()
            {
                IsSucceeded = true
            };
        }
    }
}
