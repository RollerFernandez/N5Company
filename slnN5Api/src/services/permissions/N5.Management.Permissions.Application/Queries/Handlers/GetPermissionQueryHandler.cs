using N5.Management.Commons.Dtos;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Queries.Handlers
{
    public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, PermissionDto>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public GetPermissionQueryHandler(ILifetimeScope lifetimeScope, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IPermissionsRepository permissionsRepository => UnitOfWork.Repository<IPermissionsRepository>();

        public async Task<PermissionDto> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
           
                Expression<Func<PermissionEntity, bool>> where = w => w.Id == request.PermissionId && w.Status == Constants.Core.UserStatus.ACTIVE;
                List<Expression<Func<PermissionEntity, object>>> joins = new() {
                    j => j.Employee
                };

                PermissionEntity recordDb = await permissionsRepository.GetRecordByFilter(where, joins)
                    ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(recordDb)));

            return _mapper.Map<PermissionDto>(recordDb);            
        }
    }
}
