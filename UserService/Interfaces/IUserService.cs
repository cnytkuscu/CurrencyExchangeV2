using Common.Entities;
using Common.Interfaces;

namespace UserService.Interfaces
{
    public interface IUserService
    {
        User Login(string accountUsername, string accountPassword);

        bool CheckUsernameIsExists(string username);
    }
}
