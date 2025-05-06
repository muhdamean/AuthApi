using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[Route("SoftAML/api/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService tokenService;

    public AuthController(TokenService tokenService)
    {
        this.tokenService = tokenService;
    }
    [HttpPost("users/login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null 
            || string.IsNullOrEmpty(loginRequest.Username) 
            || string.IsNullOrEmpty(loginRequest.Password))
        {
            return BadRequest(new { message = "Invalid login request" });
        }
        var accessToken = tokenService.GenerateAccessToken(loginRequest.Username);
        //var refreshToken = tokenService.GenerateRefreshToken();
        return Ok(new
        {
            token = accessToken,
            //RefreshToken = refreshToken
        });
    }

    //[HttpPost("auth")]
    //[Authorize]
    //public IActionResult Auth()
    //{
    //    return Ok(new
    //    {
    //        message = "Authenticated",
    //    });
    //}

    //[HttpGet("auth")]
    //[Authorize]
    //public IActionResult GetAuth()
    //{
    //    return Ok(new
    //    {
    //        message = "Authenticated",
    //    });
    //}
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}