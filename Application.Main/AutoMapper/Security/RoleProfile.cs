using Application.Dto.Security.Role;
using Domain.Main.Security;

namespace Application.Main.AutoMapper.Security
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
        }

    }
}
