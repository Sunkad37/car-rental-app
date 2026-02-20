using AutoMapper;
using CarRental.Application.Dto.Users;
using CarRental.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRental.Application.Queries.User;

public class GetUserByIdQueryCommand(
    ILogger<GetUserByIdQueryCommand> logger,
    IMapper mapper,
    IUserRepository repository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetUserByIdQuery for UserId: {UserId}", request.UserId);
        var userDetails = await repository.GetUserById(request.UserId);

        var userDto = mapper.Map<UserDto>(userDetails);

        logger.LogInformation("Successfully retrieved UserId: {UserId}", request.UserId);
        return userDto;
    }
}