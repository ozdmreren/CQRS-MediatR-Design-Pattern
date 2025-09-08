using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CatalogService.Infrastructure.Context
{
    public class CatalogDbContextDesignFactory : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=catalog;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";

            DbContextOptionsBuilder<CatalogDbContext> builder = new DbContextOptionsBuilder<CatalogDbContext>().UseSqlServer(connectionString);

            return new CatalogDbContext(builder.Options, null);
        }
    }
}
