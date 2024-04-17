using AutoMapper;
using Common.Entities;
using UserService.Interfaces;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository accountRepository, IMapper mapper)
        {
            _userRepository = accountRepository;
            _mapper = mapper;
        }

        public bool CheckUsernameIsExists(string username)
        {
          return _userRepository.CheckUsername(username);
        }

        public User Login(string accountUsername, string accountPassword)
        {
            var returnData = _userRepository.Login(accountUsername, accountPassword);

            return returnData;
        }
    }
}
