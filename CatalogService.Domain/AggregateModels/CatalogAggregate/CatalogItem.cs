using CatalogService.Domain.SeedWork;

namespace CatalogService.Domain.AggregateModels.CatalogAggregate
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; }
        public bool OnOrder { get; set; }
    }
}
