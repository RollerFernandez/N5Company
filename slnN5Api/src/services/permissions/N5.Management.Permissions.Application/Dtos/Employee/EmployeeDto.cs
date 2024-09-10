using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Dtos.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public ICollection<PermissionDto> Permissions { get; set; }
    }
}
