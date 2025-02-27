using auth_project.DTOs.Account;
using auth_project.Interfaces;
using auth_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace auth_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountInterface acountInterface, IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;      
        private readonly IAccountInterface _accountInterface = acountInterface;   

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await _accountInterface.GetAccount(login.UserName);
            if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                var authService = new AuthService(_configuration);
                var token = authService.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO register)
        {
            if (register == null)
            {
                return BadRequest("User data is required.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);

            if(await _accountInterface.Register(register, hashedPassword) == false){

                ModelState.AddModelError("","Something went wrong while saving");
                return StatusCode(500,ModelState);
            }

            var user = await _accountInterface.GetAccount(register.UserName);
            if(user != null && BCrypt.Net.BCrypt.Verify(register.Password, user.Password)) 
            {
                var authenticationService = new AuthService(_configuration);
                var token = authenticationService.GenerateJwtToken(user);
                return Ok(new { Token = token});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
