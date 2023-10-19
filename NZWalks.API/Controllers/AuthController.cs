using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName,
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if(identityResult.Succeeded)
            {
                if (registerRequestDTO.Roles.IsNullOrEmpty() == false)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered!");
                    }
                }
                
            }
            return BadRequest(); ;
        }

        [HttpPost("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.UserName);

            if(user != null)
            {
                bool isPasswordValid = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if(isPasswordValid)
                {
                    var userRoles = await userManager.GetRolesAsync(user);

                    if (userRoles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, userRoles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }
                }
            }
            return BadRequest("Username or password incorrect");
        }
    }
}
