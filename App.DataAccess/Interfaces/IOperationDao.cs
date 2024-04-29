using App.Domain.Operations;

namespace App.DataAccess.Interfaces;
public interface IOperationDao
{
    Task LogOperationAsync(long cardNumber, int amount);

    Task<List<Operation>> GetHistoryAsync(long cardNumber);
}
