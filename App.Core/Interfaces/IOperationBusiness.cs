using App.DTOs;

namespace App.Core.Interfaces;
public interface IOperationBusiness
{
    Task LogOperationAsync(long cardNumber, int amount);

    Task<List<OperationDto>> GetHistoryAsync(long cardNumber);
}
