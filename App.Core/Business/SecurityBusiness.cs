using App.Core.Interfaces;
using App.Core.Utils;
using App.DataAccess.Interfaces;
using App.DTOs;
using Microsoft.Extensions.Configuration;

namespace App.Core.Business;

public class SecurityBusiness : ISecurityBusiness
{
    private readonly IUserDao _userDao;
    private readonly IConfiguration _config;

    public SecurityBusiness(IUserDao userDao, IConfiguration config)
    {
        _userDao = userDao;
        _config = config;
    }

    public async Task<LogInDto> LogInUserAsync(LogInDto logIn)
    {
        var user = await _userDao.GetUser(logIn.CardNumber);
        var logInDto = new LogInDto();

        if (user == null)
        {
            logInDto.Message = "Card Number or Password invalid";
            return logInDto;
        }
        
        if (user.IsLockedOut)
        {
            logInDto.IsLockedOut = true;
            logInDto.Message = "User is locked out";
            return logInDto;
        }

        if(!CryptographyHelper.VerifyHash(logIn.Password, user.Password))
        {
            logInDto.IsPasswordValid = false;
            logInDto.Message = "Card Number or Password invalid";
            await _userDao.AddLogInTry(logIn.CardNumber);
            return logInDto;
        }
        else
        {
            logInDto.IsPasswordValid = true;
            logInDto.Token = TokenHelper.GenerateToken(user.Name, _config);
            logInDto.Message = string.IsNullOrEmpty(logInDto.Token) ? "Token Generation Failed" : "Successful LogIn";
            return logInDto;
        }
    }
}
