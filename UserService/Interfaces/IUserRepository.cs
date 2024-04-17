using Common.Entities;

namespace UserService.Interfaces
{
    public interface IUserRepository
    {
        User Login(string accountUsername, string accountPassword);
        bool CheckUsername(string username);
    }
}
