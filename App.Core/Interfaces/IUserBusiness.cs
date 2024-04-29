using App.DTOs;

namespace App.Core.Interfaces;
public interface IUserBusiness
{
    Task<BalanceDto> GetBalanceAsync(long cardNumber);

    Task<WithdrawalResponseDto> WithdrawalAsync(long cardNumber, int amount);

}
