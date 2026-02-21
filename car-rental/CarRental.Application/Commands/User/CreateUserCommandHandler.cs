using AutoMapper;
using CarRental.Application.Common.Interfaces;
using CarRental.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRental.Application.Commands.User;

public class CreateUserCommandHandler(
    ILogger<CreateUserCommandHandler> logger,
    IUserRepository repository,
    IMapper mapper,
    IPasswordService passwordService) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create User");

        var userExist = await repository.CheckIfUserExists(request.Email);
        if (userExist)
        {
            logger.LogInformation("User already exists");
        }

        var createUser = mapper.Map<Domain.Entities.User>(request);
        var (hash, salt) = passwordService.CreatePasswordHash(request.Password);

        createUser.Salt = salt;
        createUser.HashedPassword = hash;
        var result = await repository.CreateUser(createUser);
        return result;
    }
}