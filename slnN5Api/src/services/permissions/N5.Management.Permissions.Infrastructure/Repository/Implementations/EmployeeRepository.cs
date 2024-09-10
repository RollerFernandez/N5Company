using N5.Management.Commons.Extensions;

namespace N5.Management.Permissions.Infrastructure.Repository.Implementations
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity, Data.DataContext>, IEmployeeRepository
    {
        private readonly Data.DataContext context;

        public EmployeeRepository(Data.DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<EmployeeEntity> GetByCode(int Id,  bool asNoTracking = false)
        {

            var query = context.EmployeeEntity.AsQueryable();


            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(e => e.Id == Id) 
                          .Include(e => e.Permissions)
                          .ThenInclude(p => p.PermissionType);

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<EmployeeEntity> GetById(int Id)
        //{
        //    var query =  context.EmployeeEntity.Where(e => e.Id == Id)
        //                                        .Include(e => e.Permissions)
        //                                            .ThenInclude(p => p.PermissionType);

        //    return await query.FirstOrDefaultAsync();
        //}

        public async Task<ICollection<EmployeeEntity>> GetList(int Id)
        {
            var query = context.EmployeeEntity.AsQueryable().AsNoTracking().Where(e => e.Id == Id)
                                                .Include(e => e.Permissions)
                                                    .ThenInclude(p => p.PermissionType);

            return await query.ToListAsync();
        }

        public async Task<(ICollection<EmployeeEntity> Employees, int TotalCount, int TotalPages, int PageSize)> GetList(DateTime? startDate, DateTime? endDate, string status, int pageNumber, int pageSize)
        {

            var query = context.EmployeeEntity
                                .AsQueryable()
                                .AsNoTracking().WhereIf(startDate.HasValue && endDate.HasValue, e =>
                                    DateOnly.FromDateTime(e.CreatedAt) >= DateOnly.FromDateTime(startDate.Value) &&
                                    DateOnly.FromDateTime(e.CreatedAt) <= DateOnly.FromDateTime(endDate.Value))
                                .WhereIf(!string.IsNullOrEmpty(status), e => e.Status == status)
                                .Include(e => e.Permissions)
                                .ThenInclude(p => p.PermissionType);

            int totalCount = await query.CountAsync();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var employees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (employees, totalCount,totalPages, pageSize);
        }
        
    }
}

