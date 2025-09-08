using CatalogService.Application.Features.Queries.GetCatalogById.Request;
using CatalogService.Application.Features.Queries.GetCatalogById.Response;
using CatalogService.Application.Intercfaces.Repositories;
using CatalogService.Domain.AggregateModels.CatalogAggregate;
using MediatR;

namespace CatalogService.Application.Features.Queries.GetCatalogById
{
    public class GetCatalogByIQueryHandler : IRequestHandler<GetCatalogByIdQueryRequest, GetCatalogByIdQueryResponse>
    {
        private readonly ICatalogRepository catalogRepository;
        public GetCatalogByIQueryHandler(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }
        public Task<GetCatalogByIdQueryResponse> Handle(GetCatalogByIdQueryRequest request, CancellationToken cancellationToken)
        {
            CatalogItem catalog = catalogRepository.GetById(request.Id)
                ?? throw new ArgumentNullException("There is no such a catalog");

            return Task.FromResult(new GetCatalogByIdQueryResponse()
            {
                Description = catalog.Description,
                Name = catalog.Name,
                OnOrder = catalog.OnOrder,
                Price = catalog.Price
            });
        }
    }
}
