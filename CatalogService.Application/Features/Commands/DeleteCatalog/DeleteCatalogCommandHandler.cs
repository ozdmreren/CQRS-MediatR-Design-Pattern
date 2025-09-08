using CatalogService.Application.Features.Commands.DeleteCatalog.Request;
using CatalogService.Application.Features.Commands.DeleteCatalog.Response;
using CatalogService.Application.Intercfaces.Repositories;
using MediatR;

namespace CatalogService.Application.Features.Commands.DeleteCatalog
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommandRequest, DeleteCatalogCommandResponse>
    {
        private readonly ICatalogRepository catalogRepository;

        public DeleteCatalogCommandHandler(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public Task<DeleteCatalogCommandResponse> Handle(DeleteCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = catalogRepository.Remove(request.Id);
            catalogRepository.UnitOfWork.SaveEntities();

            return Task.FromResult(new DeleteCatalogCommandResponse()
            {
                IsSuccess = result
            });
        }
    }
}
