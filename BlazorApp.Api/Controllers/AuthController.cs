using BlazorApp.Api.Models;
using BlazorApp.Api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AuthController> _logger;
    private readonly IEnumerable<User> _users;

    public AuthController(ILogger<AuthController> logger, IEnumerable<User> users)
    {
        _logger = logger;
        _users = users;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_users);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        User? user = _users.SingleOrDefault(u => u.Email.ToUpper() == dto.Email.ToUpper() && u.Passwd == dto.Passwd);

        if(user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
