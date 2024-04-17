using Common;
using Common.Entities;
using Common.Interfaces;

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
            throw new NotImplementedException();
        }

        public User Login(string accountUsername, string accountPassword)
        {
            return _context.User.FirstOrDefault(x => x.Password == accountPassword && x.Username == accountUsername);
        }


    }
}
