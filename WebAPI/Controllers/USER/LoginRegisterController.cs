using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.USER;
using Newtonsoft.Json;
using Service.USER.IClass;

namespace WebAPI.Controllers.USER
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public LoginRegisterController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("SignUpPage")]
        public async Task<IActionResult> SignUpPage([FromForm] User user)
        {
            var docs = await _usersService.AddUsersAsync(user);
            return Ok(docs);
        }

    }
}
