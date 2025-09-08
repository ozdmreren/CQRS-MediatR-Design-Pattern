using CatalogService.Application.Features.Commands.DeleteCatalog.Response;
using MediatR;

namespace CatalogService.Application.Features.Commands.DeleteCatalog.Request
{
    public class DeleteCatalogCommandRequest : IRequest<DeleteCatalogCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
