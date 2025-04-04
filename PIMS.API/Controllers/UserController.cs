using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMS.Application.Commands;
using PIMS.Application.Queries;

namespace PIMS.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]

public class UserController(IMediator mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var token = await mediator.Send(command);
        if (token == "Invalid email or password") return Unauthorized();
        return Ok(new { Token = token });
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await mediator.Send(new GetAllUsersQuery() );
        return Ok(users);
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await mediator.Send(new GetUserByIdQuery { UserId = id });
        return user != null ? Ok(user) : NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await mediator.Send(new DeleteUserCommand { UserId = id });
        return Ok(result);
    }
}
