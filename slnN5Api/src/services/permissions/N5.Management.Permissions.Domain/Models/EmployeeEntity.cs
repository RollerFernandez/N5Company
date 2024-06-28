using Newtonsoft.Json;

namespace N5.Management.Permissions.Domain.Models
{
    public class EmployeeEntity : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        [JsonIgnore]
        public ICollection<PermissionEntity> Permissions { get; set; }
    }
}
