namespace N5.Management.Infrastructure.Repository.Interfaces.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetRecordByFilter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(bool asNoTracking = true);
        Task<IEnumerable<T>> GetAll(int limit);
        Task<IEnumerable<T>> GetUp(int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool asNoTracking = true);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, bool asNoTracking = true);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null, bool asNoTracking = true);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
