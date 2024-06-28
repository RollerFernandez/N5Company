namespace N5.Management.Infrastructure.Repository.Interfaces.Data
{
    public interface IUnitOfWork<Context> : IDisposable where Context : DbContext
    {
        void SaveChanges();
        bool HasChanges();
        void Dispose(bool disposing);
        Task<int> SaveChangesAsync();
        T Repository<T>() where T : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //DbContext Get();
        Context Get();
    }
}
