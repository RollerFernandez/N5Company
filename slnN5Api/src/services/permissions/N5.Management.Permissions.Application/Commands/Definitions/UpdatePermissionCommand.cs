namespace N5.Management.Permissions.Application.Commands.Definitions
{
    public class UpdatePermissionCommand : IRequest<PermissionDto>
    {
        public int PermissionId { get; set; }
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
