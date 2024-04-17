using AutoMapper;
using Common.DTOs;
using Common.Entities;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenericService<User> _service;
        private readonly IGenericService<LoginRecord> _loginRecordGenericService;
        private readonly IGenericService<AccountHistory> _accountHistoryService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IMapper mapper, IGenericService<User> service, IUserService userService, IHttpContextAccessor httpContextAccessor, IGenericService<LoginRecord> loginRecordGenericService, IGenericService<AccountHistory> accountHistoryService)
        {
            _mapper = mapper;
            _service = service;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _loginRecordGenericService = loginRecordGenericService;
            _accountHistoryService = accountHistoryService;
        }

        [Authorize(Policy = "UserService.ReadPolicy")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _service.GetAllAsync();
            var accountsDTO = _mapper.Map<List<UserDTO>>(accounts.ToList());
            return Ok(accountsDTO);
        }

        //[Authorize(Policy = "UserService.ReadPolicy")]
        [Authorize(Policy = "UserService.CreateOrUpdatePolicy")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountLoginDTO accountDTO)
        {
            if (accountDTO == null
                || string.IsNullOrEmpty(accountDTO.AccountUsername)
                || string.IsNullOrEmpty(accountDTO.AccountPassword))
            {
                return BadRequest();
            }

            var loginResult = _userService.Login(accountDTO.AccountUsername, accountDTO.AccountPassword);

            if (loginResult == null)
            {
                return NotFound();
            }
            else
            {
                var loginRecordResult = await _loginRecordGenericService.AddAsync(
                    new LoginRecord()
                    {
                        LoginIP = _httpContextAccessor.HttpContext.Request.Host.Value,
                        LoginLocation = "Turkey",
                        LoginDate = DateTime.Now,
                        UserId = loginResult.Id,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    });

                var accountHistoryResult = await _accountHistoryService.AddAsync(new AccountHistory()
                {
                    ProcessType = Common.Enums.ProcessType.Login.ToString(),
                    Definition = "User Logged in.",
                    UserId = loginResult.Id,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });

                var accountDTOMap = _mapper.Map<User>(loginResult);

                return Ok(accountDTOMap);
            }

        }
    }
}
