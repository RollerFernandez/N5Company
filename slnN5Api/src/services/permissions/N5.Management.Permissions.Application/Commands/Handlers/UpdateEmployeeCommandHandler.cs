using AutoMapper;
using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;
namespace N5.Management.Permissions.Application.Commands.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeUpdateDto>
    {
        private readonly IUnitOfWork<DataContext> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IUnitOfWork<DataContext> unitOfWork, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<EmployeeUpdateDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _unitOfWork.Repository<IEmployeeRepository>().GetByCode(request.Id) ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

                employee.Permissions.Clear();

                employee.Permissions = _mapper.Map<ICollection<PermissionEntity>>(request.Permissions);


                employee.Email = request.Email;

                _unitOfWork.SaveChanges();

                await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(employee)));

                return _mapper.Map<EmployeeUpdateDto>(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
