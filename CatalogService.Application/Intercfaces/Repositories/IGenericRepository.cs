using CatalogService.Domain.SeedWork;
using System.Linq.Expressions;

namespace CatalogService.Application.Intercfaces.Repositories
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public T GetById(Guid id, params Expression<Func<T, object>>[] includes);
        public T GetById(Guid id);
        public List<T> GetAll();
        public List<T> Get(params Expression<Func<T, object>>[] includes);
        public T Add(T entity);
        public bool Remove(Guid id);
    }
}
