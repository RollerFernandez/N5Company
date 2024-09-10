namespace N5.Management.Permissions.Infrastructure.Repository.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
    {
        Task<EmployeeEntity> GetByCode(int Id, bool asNoTracking = false);
        Task<(ICollection<EmployeeEntity> Employees, int TotalCount, int TotalPages, int PageSize)> GetList(DateTime? startDate, DateTime? endDate, string status, int pageNumber, int pageSize);
        
    }
}
