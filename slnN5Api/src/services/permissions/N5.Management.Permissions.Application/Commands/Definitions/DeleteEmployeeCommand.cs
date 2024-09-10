using N5.Management.Permissions.Application.Dtos.Employee;

namespace N5.Management.Permissions.Application.Commands.Definitions
{
    public class DeleteEmployeeCommand : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public string status { get; set; }
    }
}
