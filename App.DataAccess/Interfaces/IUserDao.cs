using App.Domain.User;

namespace App.DataAccess.Interfaces
{
    public interface IUserDao
    {
        Task<User> GetUser(long cardNumber);
        Task AddLogInTry(long cardNumber);
    }
}
