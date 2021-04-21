using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using union.Interfaces;
using union.Models.Authentication;

namespace union.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager,
                                    IJwtTokenGenerator jwtTokenGenerator,
                                    RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            var userToCreate = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(userToCreate, model.Password);

            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByNameAsync(userToCreate.UserName);

                //add role to user
                await _userManager.AddToRoleAsync(userFromDb, model.Role);

                var claim = new Claim("ClaimTitle", model.ClaimTitle);

                await _userManager.AddClaimAsync(userFromDb, claim);

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("Login")]
        //[Authorize(Policy = "CustomerRole")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //var user = await _userManager.FindByEmailAsync(loginModel.Email);
            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if (user == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            ////grab user's claims (to be added to the generated token)
            var roles = await _userManager.GetRolesAsync(user);

            ////grab user's claims (to be added to the generated token)
            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            return Ok(new
            {
                result = result,
                username = user.UserName,
                email = user.Email,
                token = _jwtTokenGenerator.generateToken(user, roles, claims)
                //token = JwtTokenGeneratorMachine(user)
            }) ;

         

            
            //return Ok(new
            //{

            //    result = result,
            //    username = user.UserName,
            //    email = user.Email,
            //    token = _jwtTokenGenerator.generateToken(user, roles, claims)
            //    //token = JwtTokenGeneratorMachine(user)
            //});
        }

        [HttpPost("confirmEmail")]
        public IActionResult confirmEmail(confirmEmailViewModel model)
        {
            return Ok();
        }
    }
}
