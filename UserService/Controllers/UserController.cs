using AutoMapper;
using Common.DTOs;
using Common.Entities;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenericService<User> _service;
        //private readonly IGenericService<LoginRecord> _loginRecordGenericService;
        //private readonly IGenericService<AccountHistory> _accountHistoryService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IMapper mapper, IGenericService<User> service, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _service = service;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _service.GetAllAsync();
            var accountsDTO = _mapper.Map<List<UserDTO>>(accounts.ToList());
            return Ok(accountsDTO);
        }
    }
}
