using App.Core.Interfaces;
using App.DataAccess.Interfaces;
using App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Business;
public class UserBusiness : IUserBusiness
{
    private readonly IUserDao _userDao;
    private readonly IOperationBusiness _opDao;

    public UserBusiness(IUserDao userDao, IOperationBusiness opDao)
    {
        _userDao = userDao;
        _opDao = opDao;
    }

    public async Task<BalanceDto> GetBalanceAsync(long cardNumber)
    {
        var result = new BalanceDto();
        var user = await _userDao.GetUser(cardNumber);

        result.UserName = user.Name;
        result.CurrentBalance = user.CurrentBalance;
        result.AccountNumber = user.AccountNumber;
        result.LastExtraction = user.LastExtraction;

        return result;
    }

    public async Task<WithdrawalResponseDto> WithdrawalAsync(long cardNumber, int amount)
    {
        var result = new WithdrawalResponseDto();
        var oldBalance = await GetBalanceAsync(cardNumber);

        if((oldBalance.CurrentBalance + amount)<0)
        {
            result.Message = "Insufficient funds";
            return result;
        }
        else
        {
            result.AmountWithdrawn = amount;
            result.PreviousBalance = oldBalance.CurrentBalance;
            await _opDao.LogOperationAsync(cardNumber, amount);
            result.NewBalance = oldBalance.CurrentBalance+amount;

            return result;
        }
    }
}
