using System.Text.Json.Serialization;

namespace N5.Management.Permissions.Domain.Models
{
    public class PermissionEntity : Entity
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        [JsonIgnore]
        public EmployeeEntity Employee { get; set; }
        public PermissionTypeEntity PermissionType { get; set; }
    }
}
