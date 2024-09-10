namespace N5.Management.Permissions.Application.Queries.Definitions
{
    public class GetListPermissionQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public int? EmployeeId { get; }

        public GetListPermissionQuery()
        {
            //EmployeeId = employeeId;
        }
    }
}
