using Common.Entities;

namespace Common.Interfaces
{
    public interface IUserRepository
    {
        User Login(string accountUsername, string accountPassword);
        bool CheckUsername(string username);
    }
}
