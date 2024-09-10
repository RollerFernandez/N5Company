namespace N5.Management.Permissions.Infrastructure.Repository.Implementations
{
    public class PermissionTypeRepository : BaseRepository<PermissionTypeEntity, Data.DataContext>, IPermissionTypeRepository
    {
        private readonly Data.DataContext context;

        public PermissionTypeRepository(Data.DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PermissionTypeEntity> GetByCode(int code)
        {
            var query = context.PermissionTypeEntity
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Id== code);

            return await query.FirstOrDefaultAsync();
        }

       

    }
}
