namespace N5.Management.Permissions.Infrastructure.Repository.Implementations
{
    public class PermissionsRepository : BaseRepository<PermissionEntity, Data.DataContext>, IPermissionsRepository
    {
        private readonly Data.DataContext context;

        public PermissionsRepository(Data.DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PermissionEntity> GetByCode(string code)
        {
            var query = context.PermissionEntity
                .AsQueryable()
                .AsNoTracking()
                .Include(e => e.Employee)
                .Where(e => e.Employee.Name == code);

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<PermissionEntity> GetById(int id)
        //{
        //    return await context.PermissionEntity.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

    }
}
