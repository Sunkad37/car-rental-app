using CarRental.Application.Dto.Users;
using MediatR;

namespace CarRental.Application.Queries.User;

public sealed record GetUserByIdQuery(int UserId) 
    : IRequest<UserDto?>;
