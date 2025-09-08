namespace CatalogService.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
