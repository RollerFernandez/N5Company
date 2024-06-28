namespace N5.Management.Permissions.Application.Queries.Definitions
{
    public class GetPermissionQuery : IRequest<PermissionDto>
    {
        public int PermissionId { get; set; }

        public GetPermissionQuery(int permissionId)
        {
            PermissionId = permissionId;
        }
    }
}
