using CQRS.Domain.SeedWork;

namespace CQRS.Domain.AggregateModels.ProductAggregate
{
    public class Product : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
