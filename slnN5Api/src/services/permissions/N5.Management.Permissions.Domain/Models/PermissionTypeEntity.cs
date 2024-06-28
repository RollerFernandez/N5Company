using Newtonsoft.Json;

namespace N5.Management.Permissions.Domain.Models
{
    public class PermissionTypeEntity : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<PermissionEntity> Permissions { get; set; }
    }
}
