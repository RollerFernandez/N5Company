using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.SharedKernel.Infrastructure.Elasticsearch.Implementations;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Commands.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly ElasticsearchService _elasticsearchService;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public CreateEmployeeCommandHandler(ILifetimeScope lifetimeScope, IMapper mapper, ElasticsearchService elasticsearchService, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _elasticsearchService = elasticsearchService;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IPermissionsRepository permissionsRepository => UnitOfWork.Repository<IPermissionsRepository>();


        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            EmployeeEntity record = _mapper.Map<EmployeeEntity>(request);

            _ = await UnitOfWork.Set<EmployeeEntity>().AddAsync(record, CancellationToken.None);
                      UnitOfWork.SaveChanges();

            _ = await _elasticsearchService.IndexDocument(_mapper.Map<EmployeeDto>(record), Constants.Core.IndexElastic.EMPLOYEE);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(record)));

            return _mapper.Map<EmployeeDto>(record);           
        }
    }
}
