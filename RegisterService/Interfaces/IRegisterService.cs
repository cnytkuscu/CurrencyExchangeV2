using Common.DTOs;

namespace RegisterService.Interfaces
{
    public interface IRegisterService
    {
        public Task<bool> Register(UserRegisterDTO userRegisterDTO);
    }
}
