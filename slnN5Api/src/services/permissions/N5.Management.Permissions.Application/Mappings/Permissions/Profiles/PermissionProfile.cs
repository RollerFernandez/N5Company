using N5.Management.Permissions.Application.Commands.Definitions;

namespace N5.Management.Permissions.Application.Mappings.Permissions.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            _ = CreateMap<PermissionEntity, PermissionDto>();
            _ = CreateMap<CreatePermissionCommand, PermissionEntity>();
            _ = CreateMap<UpdatePermissionCommand, PermissionEntity>();
        }
    }
}
