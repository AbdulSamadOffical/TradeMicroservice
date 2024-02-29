using System.Linq.Expressions;


namespace Trade.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
     
    }
}
