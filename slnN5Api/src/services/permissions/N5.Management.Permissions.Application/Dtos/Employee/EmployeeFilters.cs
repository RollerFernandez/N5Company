using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Dtos.Employee
{
    public class EmployeeFilters
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

    }
}
