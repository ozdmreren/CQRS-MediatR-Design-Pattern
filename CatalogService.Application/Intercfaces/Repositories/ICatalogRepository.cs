using CatalogService.Domain.AggregateModels.CatalogAggregate;

namespace CatalogService.Application.Intercfaces.Repositories
{
    public interface ICatalogRepository : IGenericRepository<CatalogItem>
    {
    }
}
