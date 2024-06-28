namespace N5.Management.Permissions.Application.Commands.Definitions
{
    public class CreatePermissionCommand: IRequest<PermissionDto>
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
    }
}
