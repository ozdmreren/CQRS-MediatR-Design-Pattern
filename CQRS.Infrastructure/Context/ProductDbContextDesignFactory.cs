using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CQRS.Infrastructure.Context
{
    public class ProductDbContextDesignFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContextDesignFactory() { }
        public ProductDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=product;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";

            DbContextOptionsBuilder<ProductDbContext> optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>().UseSqlServer(connectionString);

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
