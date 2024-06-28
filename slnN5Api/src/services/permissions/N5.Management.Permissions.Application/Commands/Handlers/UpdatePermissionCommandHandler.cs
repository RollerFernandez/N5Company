using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;

namespace N5.Management.Permissions.Application.Commands.Handlers
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private readonly IUnitOfWork<DataContext> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;

        public UpdatePermissionCommandHandler(IUnitOfWork<DataContext> unitOfWork, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.Repository<IPermissionsRepository>()
                .GetById(request.PermissionId);

            if (permission == null)
            {
                throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);                
            }

            permission.EmployeeId = request.EmployeeId;
            permission.PermissionTypeId = request.PermissionTypeId;
            permission.StartDate = request.StartDate;
            permission.EndDate = request.EndDate;
            permission.Reason = request.Reason;

            _unitOfWork.SaveChanges();

            await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(permission)));

            return _mapper.Map<PermissionDto>(permission);
        }
    }
}
