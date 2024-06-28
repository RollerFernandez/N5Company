namespace N5.Management.Permissions.Infrastructure.Repository.Interfaces
{
    public interface IPermissionsRepository : IBaseRepository<PermissionEntity>
    {
        Task<PermissionEntity> GetByCode(string code);
        //Task<PermissionEntity> GetById(int id);
    }
}
