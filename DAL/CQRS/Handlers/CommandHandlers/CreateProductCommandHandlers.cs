using CQRS.Domain.AggregateModels.ProductAggregate;
using CQRS.Infrastructure.Context;
using DAL.CQRS.Commands.Request;
using DAL.CQRS.Commands.Response;

namespace DAL.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandlers
    {
        private readonly ProductDbContext context;
        public CreateProductCommandHandlers(ProductDbContext context)
        {
            this.context = context;
        }
        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest request)
        {
            var created = context.Products.Add(new Product()
            {
                Name = request.ProductName,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice
            });

            context.SaveChanges();

            CreateProductCommandResponse result = new CreateProductCommandResponse()
            {
                IsSucceeded = true,
                ProductId = created.Entity.Id
            };

            return result;
        }
    }
}
