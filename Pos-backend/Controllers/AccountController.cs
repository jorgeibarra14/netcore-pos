using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pos_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = register.Email,
                    Email = register.Email
                };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                } else
                {
                    var list = new List<dynamic>();
                    foreach (var errir in result.Errors)
                    {
                        list.Add(errir.Description);
                    }
                    return Ok(list);
                }
            }
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            var valid = await userManager.CheckPasswordAsync(user, login.Password);
            if (!valid)
            {
                return BadRequest("Usuario o contraseña inválidos");
            }
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.UserData, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(120),
                IsPersistent = true
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
            return Ok(user);
        }
    }
}
