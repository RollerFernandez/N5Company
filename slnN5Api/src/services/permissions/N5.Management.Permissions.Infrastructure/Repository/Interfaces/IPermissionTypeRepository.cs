namespace N5.Management.Permissions.Infrastructure.Repository.Interfaces
{
    public interface IPermissionTypeRepository : IBaseRepository<PermissionTypeEntity>
    {
        Task<PermissionTypeEntity> GetByCode(int code);
        //Task<List<PermissionEntity>> GetAll();
        //Task<PermissionEntity> GetById(int id);
    }
}
