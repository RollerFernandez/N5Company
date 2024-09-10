using AutoMapper;
using N5.Management.Commons.Dtos;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.Producer;
using Newtonsoft.Json;
namespace N5.Management.Permissions.Application.Commands.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, EmployeeDto>
    {
        private readonly IUnitOfWork<DataContext> _unitOfWork;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandler(IUnitOfWork<DataContext> unitOfWork, IMapper mapper, KafkaProducerService kafkaProducer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _kafkaProducer = kafkaProducer;
        }

        public async Task<EmployeeDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _unitOfWork.Repository<IEmployeeRepository>().GetByCode(request.Id) ?? throw new FunctionalException(Constants.Common.Messages.RegistrationDoesNotExist);

                employee.Status=request.status;
                
                _unitOfWork.SaveChanges();

                await _kafkaProducer.ProduceAsync(new OperationMessageDto(JsonConvert.SerializeObject(employee)));

                return _mapper.Map<EmployeeDto>(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
