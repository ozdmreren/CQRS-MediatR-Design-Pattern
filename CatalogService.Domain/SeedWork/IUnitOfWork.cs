namespace CatalogService.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        public bool SaveEntities();
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
