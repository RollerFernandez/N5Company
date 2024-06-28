namespace N5.Management.Infrastructure.Repository.Implementations.Data.Base
{
    public abstract class BaseRepository<T, Context> : IBaseRepository<T> where T : class where Context : DbContext
    {
        private DbSet<T> entity;
        private readonly Context _context;

        protected BaseRepository(Context context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public virtual async Task<T> GetById(int id) => await entity.FindAsync(id);

        public virtual async Task<T> GetRecordByFilter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => entity.FirstOrDefaultAsync(predicate);

        public virtual async Task<IEnumerable<T>> GetAll(bool asNoTracking = true)
        {
            IQueryable<T> query = entity;

            if (asNoTracking) query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(int limit)
        {
            return await entity.AsQueryable().Take(limit).AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetUp(int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool asNoTracking = true)
        {
            IQueryable<T> query = entity;

            if (asNoTracking) query = query.AsNoTracking();

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, bool asNoTracking = true)
        {
            IQueryable<T> query = entity;

            if (asNoTracking) query = query.AsNoTracking();

            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null, bool asNoTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (asNoTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public virtual Task<int> CountAll() => entity.AsQueryable().AsNoTracking().CountAsync();

        public virtual Task<int> CountWhere(Expression<Func<T, bool>> predicate) => entity.AsNoTracking().CountAsync(predicate);
    }
}
