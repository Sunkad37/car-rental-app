using AutoMapper;
using CarRental.Domain.Entities;

namespace CarRental.Application.Dto.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Salt, opt => opt.Ignore())
            .ForMember(dest => dest.HashedPassword, opt => opt.Ignore());
    }
}