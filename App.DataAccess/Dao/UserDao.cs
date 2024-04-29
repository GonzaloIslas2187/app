using App.DataAccess.Interfaces;
using App.Domain.User;
using App.SQLManagement.Dbc;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Dao;
public class UserDao : IUserDao
{
    private readonly AppDbc _appDbc;

    public UserDao(AppDbc appDbc)
    {
        _appDbc = appDbc;
    }

    public async Task AddLogInTry(long cardNumber)
    {
        var user = await _appDbc.Users
            .FirstOrDefaultAsync(x => x.CardNumber == cardNumber);

        user.FailedTries++;

        if (user.FailedTries >= 3)
            user.IsLockedOut = true;

        _appDbc.Users.Update(user);    

        await _appDbc.SaveChangesAsync();
    }

    public async Task<User> GetUser(long cardNumber) 
        =>
        _appDbc.Users.Find(cardNumber);
}
