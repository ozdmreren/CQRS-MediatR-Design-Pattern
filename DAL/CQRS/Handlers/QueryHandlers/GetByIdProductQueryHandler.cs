using CQRS.Domain.AggregateModels.ProductAggregate;
using CQRS.Infrastructure.Context;
using DAL.CQRS.Queries.Request;
using DAL.CQRS.Queries.Response;

namespace DAL.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        private readonly ProductDbContext context;
        public GetByIdProductQueryHandler(ProductDbContext context)
        {
            this.context = context;
        }
        public GetByIdProductQueryResponse GetProductById(GetByIdProductQueryRequest request)
        {
            Product? exist = context.Products.Find(request.Id);

            return new GetByIdProductQueryResponse()
            {
                CreatedDate = DateTime.Now,
                ProductId = request.Id,
                ProductName = exist.Name,
                Quantity = exist.Quantity,
                UnitPrice = exist.UnitPrice
            };
        }
    }
}
