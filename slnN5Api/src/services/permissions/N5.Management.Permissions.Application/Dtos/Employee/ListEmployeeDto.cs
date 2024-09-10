using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Dtos.Employee
{
    public class ListEmployeeDto
    {
        public ICollection<EmployeeDto> items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
