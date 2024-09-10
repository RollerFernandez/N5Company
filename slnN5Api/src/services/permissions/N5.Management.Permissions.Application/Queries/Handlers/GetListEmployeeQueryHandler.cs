using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Employee.Application.Queries.Handlers
{
    public class GetListEmployeeQueryHandler : IRequestHandler<GetListEmployeeQuery, ListEmployeeDto>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public GetListEmployeeQueryHandler(ILifetimeScope lifetimeScope, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IEmployeeRepository employeeRepository => UnitOfWork.Repository<IEmployeeRepository>();

        public async Task<ListEmployeeDto> Handle(GetListEmployeeQuery request, CancellationToken cancellationToken)
        {

            var (Employees, TotalCount, TotalPages, PageSize) = await employeeRepository.GetList(request.StartDate, request.EndDate, request.Status, request.PageNumber, request.PageSize);
             
            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(Employees)));

            ICollection<EmployeeDto> employeeDtos = _mapper.Map<ICollection<EmployeeDto>>(Employees);

           
            var result = new ListEmployeeDto()
            {
                items = employeeDtos,
                TotalCount = TotalCount,
                TotalPages = TotalPages,
                PageSize = PageSize
            };

            return result;
          
        }
    }
}
