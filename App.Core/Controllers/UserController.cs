using App.Core.Interfaces;
using App.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] 
public class UserController : ControllerBase
{
    private readonly IUserBusiness _userB;

    public UserController(IUserBusiness userB)
    {
        _userB = userB;
    }

    [HttpGet]
    [Route("CheckBalance")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckBalance(long cardNumber)
    {
        return Ok(await _userB.GetBalanceAsync(cardNumber));
    }

    [HttpPost]
    [Route("Withdrawal")]
    [AllowAnonymous]
    public async Task<IActionResult> Withdrawal([FromBody] WithdrawalRequestDto withdrawal)
    {
        if(withdrawal.Amount>0)
            withdrawal.Amount = withdrawal.Amount * -1;

        var result = await _userB.WithdrawalAsync(withdrawal.CardNumber, withdrawal.Amount);

        if (string.IsNullOrEmpty(result.Message))
            return StatusCode(406, result.Message);
        else
            return Ok(result);
    }
}
