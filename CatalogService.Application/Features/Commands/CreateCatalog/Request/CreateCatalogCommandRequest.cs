using CatalogService.Application.Features.Commands.CreateCatalog.Response;
using MediatR;

namespace CatalogService.Application.Features.Commands.CreateCatalog.Request
{
    public class CreateCatalogCommandRequest : IRequest<CreateCatalogCommandResponse>
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; }
        public bool OnOrder { get; set; }
    }
}
