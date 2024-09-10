using N5.Management.Commons.Dtos;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Queries.Handlers
{
    public class GetListPermissionTypeQueryHandler : IRequestHandler<GetListPermissionTypeQuery, IEnumerable<PermissionTypeDto>>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public GetListPermissionTypeQueryHandler(ILifetimeScope lifetimeScope, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IPermissionTypeRepository permissionsTypeRepository => UnitOfWork.Repository<IPermissionTypeRepository>();

        public async Task<IEnumerable<PermissionTypeDto>> Handle(GetListPermissionTypeQuery request, CancellationToken cancellationToken)
        {


            IEnumerable<PermissionTypeEntity> recordDb = await permissionsTypeRepository.GetAll(true)
                    ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(recordDb)));

            return _mapper.Map<IEnumerable<PermissionTypeDto>>(recordDb);            
        }
    }
}
