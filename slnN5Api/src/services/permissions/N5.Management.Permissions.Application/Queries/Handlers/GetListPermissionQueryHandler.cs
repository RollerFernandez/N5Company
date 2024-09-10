using Microsoft.AspNetCore.Mvc;
using N5.Management.Commons.Dtos;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Queries.Handlers
{
    public class GetListPermissionQueryHandler : IRequestHandler<GetListPermissionQuery, IEnumerable<PermissionDto>>
    {
        private readonly Lazy<IUnitOfWork<DataContext>> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;


        public GetListPermissionQueryHandler(ILifetimeScope lifetimeScope, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = new Lazy<IUnitOfWork<DataContext>>(() => lifetimeScope.Resolve<IUnitOfWork<DataContext>>());
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        private IUnitOfWork<DataContext> UnitOfWork => _unitOfWork.Value;
        private IPermissionsRepository permissionsRepository => UnitOfWork.Repository<IPermissionsRepository>();

        public async Task<IEnumerable<PermissionDto>> Handle(GetListPermissionQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<PermissionEntity> recordDb = await permissionsRepository.GetAll()
                    ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(recordDb)));

            return _mapper.Map<IEnumerable<PermissionDto>>(recordDb);            
        }
    }
}
