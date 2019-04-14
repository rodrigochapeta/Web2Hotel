using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Hotel.Dto;
using Web2Hotel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Web2Hotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AuthController(AccountService accountService)
        {
            _accountService = accountService;
        }



        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var jwtToken = _accountService.Login(loginDto);

            if (jwtToken == null)
            {
                return Unauthorized();
            }

            return Ok(jwtToken);
        }

    }
}