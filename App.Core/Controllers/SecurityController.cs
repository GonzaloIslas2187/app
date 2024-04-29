using App.Core.Interfaces;
using App.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class SecurityController : ControllerBase
{
    private readonly ISecurityBusiness _sec;

    public SecurityController(ISecurityBusiness sec)
    {
        _sec = sec;
    }

    [HttpPost]
    [Route("LogInUser")]
    [AllowAnonymous]
    public async Task<IActionResult> LogInUser([FromBody] UserLogInDto logIn)
    {
        var logInDto = new LogInDto();
        logInDto.CardNumber = logIn.CardNumber;
        logInDto.Password = logIn.Password;

        var result = await _sec.LogInUserAsync(logInDto);

        if (string.IsNullOrEmpty(logInDto.Token))
            return Unauthorized(logInDto.Message);
        else
            return Ok(logInDto.Token);
    }
}