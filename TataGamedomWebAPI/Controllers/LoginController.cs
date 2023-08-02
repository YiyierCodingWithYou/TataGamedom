using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;
using Microsoft.AspNetCore.Authorization;

namespace TataGamedomWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{

		private readonly AppDbContext _context;

		public LoginController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public string Login(LoginDTO dto)
		{
			var user = (from u in _context.Members
						where u.Account == dto.Account
						&& u.Password == dto.Password
						select u).SingleOrDefault();

			if (user == null)
			{
				return "帳號密碼錯誤";
			}
			else
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Account),
					new Claim("FullName", user.Name),
                   // new Claim(ClaimTypes.Role, "Administrator")
                };

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
				return "ok";
			}
			
		}
		[Authorize]
		[HttpDelete]
		public void logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}
		[HttpGet("NoLogin")]
		public string noLogin()
		{
			return "未登入";
		}
	}
}
