using Common.Entities;

namespace Common.Interfaces
{
    public interface IUserService
    {
        User Login(string accountUsername, string accountPassword);
    }
}
