namespace N5.Management.Permissions.Application.Dtos.Permissions
{
    public class PermissionUpdateDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
