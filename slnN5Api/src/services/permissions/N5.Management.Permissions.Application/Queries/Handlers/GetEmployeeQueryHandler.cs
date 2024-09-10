using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Employee.Application.Queries.Handlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public GetEmployeeQueryHandler(ILifetimeScope lifetimeScope, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IEmployeeRepository employeeRepository => UnitOfWork.Repository<IEmployeeRepository>();

        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
           
            EmployeeEntity recordDb = await employeeRepository.GetByCode(request.EmployeeId, true)
              ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(recordDb)));

            return _mapper.Map<EmployeeDto>(recordDb);            
        }
    }
}
