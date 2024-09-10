namespace N5.Management.Permissions.Infrastructure.Repository.Interfaces
{
    public interface IPermissionsRepository : IBaseRepository<PermissionEntity>
    {
        Task<PermissionEntity> GetByCode(int code);
        //Task<List<PermissionEntity>> GetAll();
        //Task<PermissionEntity> GetById(int id);
    }
}
