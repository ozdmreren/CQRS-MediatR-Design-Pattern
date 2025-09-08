using CatalogService.Application.Features.Queries.GetCatalogById.Response;
using MediatR;

namespace CatalogService.Application.Features.Queries.GetCatalogById.Request
{
    public class GetCatalogByIdQueryRequest : IRequest<GetCatalogByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
