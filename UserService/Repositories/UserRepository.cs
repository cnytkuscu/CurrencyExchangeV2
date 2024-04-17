using Common;
using Common.Entities;
using UserService.Interfaces;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CheckUsername(string username)
        {
            return _context.User.Select(x => x.Username == username).Count() > 0 ? true : false;
        }

        public User Login(string accountUsername, string accountPassword)
        {
            return _context.User.FirstOrDefault(x => x.Password == accountPassword && x.Username == accountUsername);
        }


    }
}
