using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrialApis.Models.DTOs.AuthDtos;
using TrialApis.Repositories;

namespace TrialApis.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthController : ControllerBase
   {
      private readonly UserManager<IdentityUser> _userManager;
      private readonly ITokenRepository _tokenRepository;
      public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
      {
         _userManager = userManager;
         _tokenRepository = tokenRepository;
      }

      [HttpPost]
      [Route("Register")]
      public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
      {
         var identityUser = new IdentityUser
         {
            UserName = registerRequestDto.Username,
            Email = registerRequestDto.Username
         };

         var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

         if (identityResult.Succeeded)
         {
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
               identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
               if (identityResult.Succeeded)
               {
                  return Ok("User was registerd! please login.");
               }
            }
         }

         return BadRequest("Something went wrong!");
      }

      [HttpPost]
      [Route("Login")]
      public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
      {
         var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
         if (user != null)
         {
            var checkUserPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (checkUserPassword)
            {
               var roles = await _userManager.GetRolesAsync(user);
               if (roles != null)
               {
                  var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                  return Ok(jwtToken);
               }
               //Create token
               return Ok("dsf");
            }
         }
         return BadRequest("Email or password is incorrect!");
      }
   }
}