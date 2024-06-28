using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.SharedKernel.Infrastructure.Elasticsearch.Implementations;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Commands.Handlers
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, PermissionDto>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly ElasticsearchService _elasticsearchService;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public CreatePermissionCommandHandler(ILifetimeScope lifetimeScope, IMapper mapper, ElasticsearchService elasticsearchService, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _elasticsearchService = elasticsearchService;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IPermissionsRepository permissionsRepository => UnitOfWork.Repository<IPermissionsRepository>();


        public async Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {

            PermissionEntity record = _mapper.Map<PermissionEntity>(request);

            _ = await UnitOfWork.Set<PermissionEntity>().AddAsync(record, CancellationToken.None);
                      UnitOfWork.SaveChanges();

            _ = await _elasticsearchService.IndexDocument<PermissionEntity>(record, Constants.Core.IndexElastic.PERMISSIONS);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(record)));

            return _mapper.Map<PermissionDto>(record);           
        }
    }
}
