using CatalogService.Application.Features.Commands.CreateCatalog.Request;
using CatalogService.Application.Features.Commands.CreateCatalog.Response;
using CatalogService.Application.Intercfaces.Repositories;
using CatalogService.Domain.AggregateModels.CatalogAggregate;
using MediatR;

namespace CatalogService.Application.Features.Commands.CreateCatalog
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommandRequest, CreateCatalogCommandResponse>
    {
        private readonly ICatalogRepository catalogRepository;
        public CreateCatalogCommandHandler(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }
        public async Task<CreateCatalogCommandResponse> Handle(CreateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            CatalogItem created = catalogRepository.Add(new CatalogItem()
            {
                Description = request.Description,
                Name = request.Name,
                OnOrder = request.OnOrder,
                Price = request.Price,
            });

            await catalogRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new CreateCatalogCommandResponse()
            {
                Id = created.Id,
                IsSuccees = true
            };
        }
    }
}
