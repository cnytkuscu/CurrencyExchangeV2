using AutoMapper;
using Common.DTOs;
using Common.Entities;
using Common.Interfaces;
using RegisterService.Interfaces;
using UserService.Interfaces;

namespace RegisterService.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserService _userService;
        private readonly IGenericService<User> _userGenericService;
        private readonly IMapper _mapper;

        public RegisterService(IUserService userService, IGenericService<User> userGenericService, IMapper mapper)
        {
            _userService = userService;
            _userGenericService = userGenericService;
            _mapper = mapper;
        }

        public async Task<bool> Register(UserRegisterDTO userRegisterDTO)
        {
            if (_userService.CheckUsernameIsExists(userRegisterDTO.Username))
            {
                if (Common.Methods.CommonMethods.IsPasswordComplex(userRegisterDTO.Password))
                {
                    if (Common.Methods.CommonMethods.IsValidEmail(userRegisterDTO.Mail))
                    {
                        if (Common.Methods.CommonMethods.IsValidBirthDate(userRegisterDTO.DateOfBirth))
                        {
                            var mappedUser = _mapper.Map<User>(userRegisterDTO);
                            var returnData = await _userGenericService.AddAsync(mappedUser);

                        }
                    }
                }
            }
            return false;
        }
    }
}
