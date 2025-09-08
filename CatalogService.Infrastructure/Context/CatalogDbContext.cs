using CatalogService.Domain.AggregateModels.CatalogAggregate;
using CatalogService.Domain.SeedWork;
using CatalogService.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Context
{
    public class CatalogDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "catalog";
        private readonly IMediator mediator;
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        public bool SaveEntities()
        {

            base.SaveChanges();

            return true;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
        }
    }
}
