using CQRS.Infrastructure.Context;
using DAL.CQRS.Queries.Request;
using DAL.CQRS.Queries.Response;

namespace DAL.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler
    {
        private readonly ProductDbContext context;
        public GetAllProductQueryHandler(ProductDbContext context)
        {
            this.context = context;
        }
        public List<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest request)
        {
            return context.Products.Select(s => new GetAllProductQueryResponse()
            {
                CreatedDate = DateTime.Now,
                ProductId = s.Id,
                ProductName = s.Name,
                Quantity = s.Quantity,
                UnitPrice = s.UnitPrice
            }).ToList();
        }
    }
}
