using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Dtos.Employee
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<PermissionUpdateDto> Permissions { get; set; }
    }
}
