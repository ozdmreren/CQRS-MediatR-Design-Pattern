using CatalogService.Application.Intercfaces.Repositories;
using CatalogService.Domain.SeedWork;
using CatalogService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogService.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CatalogDbContext context;
        public GenericRepository(CatalogDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUnitOfWork UnitOfWork => context;

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public List<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            foreach (var include in includes)
            {
                Console.WriteLine("Include: {include}", include.ToString());
                Console.WriteLine("Include: {include}", include);
                query = query.Include(include);
            }

            return query.ToList();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            foreach (var include in includes)
            {
                Console.WriteLine("Include: {include}", include);
                query = query.Include(include);
            }

            return query.FirstOrDefault(s => s.Id == id);
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Remove(Guid id)
        {
            T entity = GetById(id);
            DbSet<T> dbSet = context.Set<T>();
            dbSet.Remove(entity);

            return true;
        }
    }
}
