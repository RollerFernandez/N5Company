namespace N5.Management.Permissions.Application.Dtos.Permissions
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public EmployeeEntity Employee { get; set; }
        public PermissionTypeEntity PermissionType { get; set; }
    }
}
