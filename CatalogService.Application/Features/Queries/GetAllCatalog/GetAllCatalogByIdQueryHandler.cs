using CatalogService.Application.Features.Queries.GetAllCatalog.Response;
using CatalogService.Application.Features.Queries.GetAllCatalogById.Request;
using CatalogService.Application.Intercfaces.Repositories;
using MediatR;

namespace CatalogService.Application.Features.Queries.GetAllCatalogById
{
    public class GetAllCatalogByQueryHandler : IRequestHandler<GetAllCatalogQueryRequest, List<GetAllCatalogQueryResponse>>
    {
        private readonly ICatalogRepository catalogRepository;
        public GetAllCatalogByQueryHandler(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public Task<List<GetAllCatalogQueryResponse>> Handle(GetAllCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllCatalogQueryResponse> list = new List<GetAllCatalogQueryResponse>();
            foreach (var item in catalogRepository.GetAll())
            {
                list.Add(new GetAllCatalogQueryResponse()
                {
                    Description = item.Description,
                    Name = item.Name,
                    OnOrder = item.OnOrder,
                    Price = item.Price
                });
            }
            return Task.FromResult(list);
        }
    }
}
