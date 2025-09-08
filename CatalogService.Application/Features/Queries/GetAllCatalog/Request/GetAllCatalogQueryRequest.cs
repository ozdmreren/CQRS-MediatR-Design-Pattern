using CatalogService.Application.Features.Queries.GetAllCatalog.Response;
using MediatR;

namespace CatalogService.Application.Features.Queries.GetAllCatalogById.Request
{
    public class GetAllCatalogQueryRequest : IRequest<List<GetAllCatalogQueryResponse>>
    {
    }
}
