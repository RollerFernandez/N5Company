using N5.Management.Permissions.Application.Dtos.Employee;

namespace N5.Management.Permissions.Application.Queries.Definitions
{
    public class GetListEmployeeQuery : IRequest<ListEmployeeDto>
    {
        public DateTime? StartDate { get;}
        public DateTime? EndDate { get; }
        public string? Status { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public GetListEmployeeQuery(DateTime? startDate, DateTime? endDate, string? status, int pageNumber, int pageSize)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
