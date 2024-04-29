using App.DataAccess.Interfaces;
using App.Domain.Operations;
using App.SQLManagement.Dbc;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Dao;
public class OperationDao : IOperationDao
{
    private readonly AppDbc _appDbc;

    public OperationDao(AppDbc appDbc)
    {
        _appDbc = appDbc;
    }

    public async Task<List<Operation>> GetHistoryAsync(long cardNumber)
    {
        return await _appDbc.Operations.Where(x => x.CardNumber == cardNumber).ToListAsync();
    }

    public Task LogOperationAsync(long cardNumber, int amount)
    {
        _appDbc.Operations.Add(new Operation
        {
            CardNumber = cardNumber,
            Amount = amount,
            Date = DateTime.Now,
        });

        _appDbc.SaveChanges();

        return Task.CompletedTask;
    }
}
