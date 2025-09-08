using CQRS.Domain.AggregateModels.ProductAggregate;
using CQRS.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "products";
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}
