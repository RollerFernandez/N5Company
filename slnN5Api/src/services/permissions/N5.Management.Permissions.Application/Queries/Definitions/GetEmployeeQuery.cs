using N5.Management.Permissions.Application.Dtos.Employee;

namespace N5.Management.Permissions.Application.Queries.Definitions
{
    public class GetEmployeeQuery : IRequest<EmployeeDto>
    {
        public int EmployeeId { get;}

        public GetEmployeeQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
