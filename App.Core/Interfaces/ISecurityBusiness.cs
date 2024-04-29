using App.DTOs;

namespace App.Core.Interfaces;

public interface ISecurityBusiness
{
    Task<LogInDto> LogInUserAsync(LogInDto logIn);
}
