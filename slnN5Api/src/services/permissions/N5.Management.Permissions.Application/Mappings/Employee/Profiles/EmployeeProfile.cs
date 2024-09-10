using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Employee;

namespace N5.Management.Permissions.Application.Mappings.Employee.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
          

            _ = CreateMap<EmployeeEntity, EmployeeDto>()
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
            
            _ = CreateMap<PermissionEntity, PermissionDto>()
                .ForMember(dest => dest.PermissionType, opt => opt.MapFrom(src => src.PermissionType));

            _ = CreateMap<PermissionTypeEntity, PermissionTypeDto>();

            _ = CreateMap<PermissionTypeDto, PermissionTypeEntity>();
            _ = CreateMap<CreateEmployeeCommand, EmployeeEntity>()
               .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions)).ReverseMap();

            _ = CreateMap<UpdateEmployeeCommand, EmployeeEntity>()
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions)).ReverseMap();

            _ = CreateMap<EmployeeEntity, EmployeeUpdateDto>()
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            _ = CreateMap<PermissionDto, PermissionEntity>();
            _ = CreateMap<PermissionUpdateDto, PermissionEntity>();
            _ = CreateMap<PermissionEntity, PermissionUpdateDto>();


        }
    }
}
