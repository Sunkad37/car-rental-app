using car_rental_api.ApiResponse;
using CarRental.Application.Dto.Users;
using CarRental.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));

        if (user is null)
        {
            var errorResponse = new ApiResponse<UserDto>
            {
                Status = "error",
                Data = null!,
                ErrorCode = StatusCodes.Status404NotFound.ToString(),
                Message = "User not found"
            };
            return NotFound(errorResponse);
        }

        var successResponse = new ApiResponse<UserDto>
        {
            Status = "success",
            Data = user,
            ErrorCode = null!,
            Message = "User retrieved successfully"
        };
        return Ok(successResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request)
    {
        try
        {
            var result = await mediator.Send(request);

            var response = ApiResponse<string>.Success(
                result.ToString(),
                "User created successfully");

            return Ok(response);
        }
        catch (Exception ex)
        {
            var response = ApiResponse<string>.Failure(
                "USER_CREATION_FAILED",
                ex.Message);

            return BadRequest(response);
        }
    }
}