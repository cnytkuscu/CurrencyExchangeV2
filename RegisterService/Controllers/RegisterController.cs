using AutoMapper;
using Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterService.Interfaces;

namespace RegisterService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService, IMapper mapper)
        {
            _registerService = registerService;
            _mapper = mapper;
        }

        [Authorize(Policy = "RegisterService.CreateOrUpdatePolicy")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            //Check Username is exists or not
           var returnData = await _registerService.Register(userRegisterDTO);

            return Ok(returnData);
             
        }
    }
}
