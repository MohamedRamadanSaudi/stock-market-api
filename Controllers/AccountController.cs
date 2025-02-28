using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using stock_market_api.Dtos.Account;
using stock_market_api.models;

namespace stock_market_api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createUserResult = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (!createUserResult.Succeeded)
                {
                    return BadRequest(createUserResult.Errors);
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (!addToRoleResult.Succeeded)
                {
                    return BadRequest(addToRoleResult.Errors);
                }

                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    }
}