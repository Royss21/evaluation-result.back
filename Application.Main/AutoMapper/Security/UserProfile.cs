using Application.Dto.Security.Authentication;
using Application.Dto.Security.Role;
using Application.Dto.Security.User;
using Application.Security.Entities;
using Domain.Main.Security;

namespace Application.Main.AutoMapper.Security
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserInfoTokenDto>()
                    .ForMember(x => x.Email, m => m.MapFrom(d => d.Email))
                    .ForMember(x => x.UserName, m => m.MapFrom(d => d.UserName))
                    .ForMember(x => x.FullName, m => m.MapFrom(d => $"{d.Names} {d.LastName} {d.MiddleName}"))
                    .ForMember(x => x.Password, m => m.MapFrom(d => d.Password))
                    .ForMember(x => x.HashType, m => m.MapFrom(d => d.HashType))
                    .ReverseMap();

            CreateMap<UserTokenApp, AccessDto>().ReverseMap();
            CreateMap<UserCreateDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(x => x.Roles, m => m.MapFrom(d => d.UserRoles.Select(s => new RoleDto { Id = s.Role.Id, Name = s.Role.Name }).ToList()));
        }

    }
}
