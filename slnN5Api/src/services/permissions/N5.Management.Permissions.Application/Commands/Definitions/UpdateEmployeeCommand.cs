using N5.Management.Permissions.Application.Dtos.Employee;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Commands.Definitions
{
    public class UpdateEmployeeCommand : IRequest<EmployeeUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<PermissionUpdateDto> Permissions { get; set; }
    }
}
