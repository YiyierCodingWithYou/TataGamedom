using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.DTOs.Members;
using TataGamedomWebAPI.Models.DTOs.News;
using TataGamedomWebAPI.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Cors;
using static System.Net.WebRequestMethods;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

		// POST: api/Members/Login
		[EnableCors("AllowCookie")]
		[HttpPost("Login")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		//public string Login(LoginDTO dto)
		public async Task<ActionResult> Login(LoginDTO dto)
		{
            var hashOrigPwd = HashUtility.ToSHA256(dto.Password, "!@#$$DGTEGYT");

			var user = (from u in _context.Members
						where u.Account == dto.Account
						&& u.Password == hashOrigPwd
						select u).SingleOrDefault();

			if (user == null)
			{
				return BadRequest("帳號密碼錯誤");
			}
			if (user.ActiveFlag == false)
			{
				return BadRequest("此帳號已被停權，請聯繫管理員");
			}
			else
			{
				if (user.IsConfirmed != true)
				{
					return BadRequest("帳號尚未啟用，請先啟用帳號");
				}

				var currentDate = DateTime.Now;
				var age = currentDate.Year - user.Birthday.Year;
				if (currentDate.Month < user.Birthday.Month || (currentDate.Month == user.Birthday.Month && currentDate.Day < user.Birthday.Day))
				{
					age--; // 如果生日尚未到來，則減少一歲
				}

				user.LastOnlineTime = DateTime.Now;
				_context.SaveChanges();
				//string memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
				//string memberName = HttpContext.User.FindFirstValue("FullName");
				var claims = new List<Claim>
				{
                    //這邊可以自定義
					//new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), //抓ID
					new Claim(ClaimTypes.Name, user.Account),//抓帳號
                    new Claim("MembersAccount",user.Account),
					new Claim("MembersName", user.Name),//抓名字
                    new Claim("Membersid",user.Id.ToString())//抓ID欄位
                };


				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

				return Ok(new { Name = user.Name, Age = age });

            }

        }

		private void ClearReturnToRoute()
		{
			var returnToRoute = HttpContext.Request.Headers["ReturnToRoute"].ToString();
			if (!string.IsNullOrEmpty(returnToRoute))
			{
				HttpContext.Response.Headers.Remove("ReturnToRoute");
				Response.Cookies.Append("ReturnToRoute", returnToRoute, new CookieOptions
				{
					HttpOnly = true,
					Expires = DateTime.UtcNow.AddMinutes(-1) // Expire immediately
				});
			}
		}



		[Authorize]
		[EnableCors("AllowCookie")]
		[HttpDelete("Logout")]
		public void Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}

		[HttpGet("NoLogin")]
		public string noLogin()
		{
			return "未登入";
		}

		//// GET: api/Members
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
		//{
		//  if (_context.Members == null)
		//  {
		//      return NotFound();
		//  }
		//    return await _context.Members.ToListAsync();
		//}

		// GET: api/Members/
		[EnableCors("AllowCookie")]
		[HttpGet]
		public async Task<ActionResult<MembersDto>> GetMember()
		{
			var account = HttpContext.User.FindFirstValue("MembersAccount");
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);

			if (user== null)
			{
				return NotFound();
			}

			var currentDate = DateTime.Now;
			var age = currentDate.Year - user.Birthday.Year;
			if (currentDate.Month < user.Birthday.Month || (currentDate.Month == user.Birthday.Month && currentDate.Day < user.Birthday.Day))
			{
				age--; // 如果生日尚未到來，則減少一歲
			}

			var memberDto = new MembersDto
			{
				Id = user.Id,
				Name = user.Name,
				Age = age,
				Account = user.Account,
				Birthday = user.Birthday,
				Email = user.Email,
				Phone = user.Phone,
				IconImg = user.IconImg,
				ActiveFlag = user.ActiveFlag,
				LastOnlineTime = DateTime.Now 
			};
			return Ok(memberDto);
		}

		// PUT: api/Members/
		[EnableCors("AllowCookie")]
		[HttpPut]
		public async Task<IActionResult> PutMember(MembersDto memberDto, string iconImgFileName)
		{

			var account = HttpContext.User.FindFirstValue("MembersAccount");
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);

			if (user == null)
			{
				return NotFound();
			}

			// 更新 member 物件的屬性
			user.Name = memberDto.Name;
			user.Phone = memberDto.Phone;
			if (!string.IsNullOrEmpty(iconImgFileName))
			{
				user.IconImg = iconImgFileName;
			}
			await _context.SaveChangesAsync();
	
			return NoContent();
		}

		// POST: api/Members
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[EnableCors("AllowCookie")]
		[HttpPost("Register")]
		public async Task<ActionResult<Member>> Register(RegisterDto registerDto)
		{
			if (_context.Members == null)
			{
				return Problem("Entity set 'AppDbContext.Members'  is null.");
			}

			if (await _context.Members.AnyAsync(m => m.Account == registerDto.Account))
			{
				return BadRequest("此帳號已經有人使用過囉");
			}

			if (await _context.Members.AnyAsync(m => m.Email == registerDto.Email))
			{
				return BadRequest("此信箱已經有人使用過囉");
			}

			if (registerDto.Password != registerDto.CheckPassword)
			{
				return BadRequest("兩次輸入的密碼不相符，請重新確認。");
			}

			//if (registerDto.IsConfirmed != true)
			//{
			//	return BadRequest("帳號尚未啟用");
			//}

			var hashOrigPwd = HashUtility.ToSHA256(registerDto.Password, "!@#$$DGTEGYT");
		
			var tataicon = "tataUserIcon.jpg";
			//驗證用不寫入SQL
			registerDto.CheckPassword = null;

			//更新紀錄，重給一個confirmCode
			var confirmCode = Guid.NewGuid().ToString("N");

			Member member = new Member
			{
				Id = registerDto.Id,
				Name = registerDto.Name,
				Account = registerDto.Account,
				Password = hashOrigPwd,
				Birthday = registerDto.Birthday,
				Email = !string.IsNullOrEmpty(registerDto.Email) ? registerDto.Email : null,
				Phone = !string.IsNullOrEmpty(registerDto.Phone) ? registerDto.Phone : null,
				RegistrationDate = DateTime.Now,
				IconImg = registerDto.IconImg,
				IsConfirmed = false,
				ConfirmCode = confirmCode,
				ActiveFlag = true
			};
			if (registerDto.IconImg == null)
			{
				member.IconImg = tataicon;
			}

			await _context.Members.AddAsync(member);
			await _context.SaveChangesAsync();

			try
			{
				// 生成email連結
				var urlTemplate = "https://localhost:3000/Members/ActiveRegister?memberId={0}&confirmCode={1}";

				// 若成功，寄送郵件

				// 發email
				var url = string.Format(urlTemplate, member.Id, confirmCode);
				new EmailHelper().SendConfirmRegisterEmail(url, member.Name, member.Email);

				return CreatedAtAction("GetMember", new { id = member.Id }, member);
			}
			catch (Exception ex)
			{
				// 在這裡處理錯誤，您可以記錄錯誤、通知管理者，或者採取適當的回應措施
				// 以下是一個簡單的例子，您可以根據實際需求進行調整

				Console.WriteLine("發生錯誤：" + ex.Message);
				return StatusCode(500, "內部伺服器錯誤，請稍後再試。");
			}
		}

		[HttpPost("ActiveRegister")]
		public async Task<ActionResult<string>> ActiveRegister(ActiveRegisterDTO dto)
		{
			var member = await _context.Members.FindAsync(dto.MemberId);

			if (member == null)
			{
				return NotFound();
			}

			if (member.IsConfirmed)

			{
				return BadRequest("此帳號已經啟用過囉");
			}

			if (member.ConfirmCode != dto.ConfirmCode)
			{
				return BadRequest("驗證碼錯誤");
			}


			member.IsConfirmed = true;
			member.ConfirmCode = null;
			await _context.SaveChangesAsync();

			// 轉跳到首頁
			return Ok();
		}

		[HttpPost("ForgetPassword")]
		public async Task<ActionResult<string>> ForgetPassword(ForgetPasswordDTO dto)
		{
			var member = await _context.Members.FirstOrDefaultAsync(m => m.Account == dto.Account);

			if (member == null)
			{
				return NotFound();
			}

			if (member.IsConfirmed == false)

			{
				return BadRequest("您還沒有啟用本帳號，請先完成才能重設密碼");
			}

			try
			{
				// 生成email連結
				var urlTemplate = "https://localhost:3000/Members/ResetPassword?memberId={0}&confirmCode={1}";

				// 若成功，寄送郵件

				var confirmCode = Guid.NewGuid().ToString("N");
				member.ConfirmCode = confirmCode;
				await _context.SaveChangesAsync();

				// 發email
				var url = string.Format(urlTemplate, member.Id, confirmCode);
				new EmailHelper().SendForgetPasswordEmail(url, member.Account, member.Email);

				return CreatedAtAction("GetMember", new { id = member.Id }, member);
			}
			catch (Exception ex)
			{
				// 在這裡處理錯誤，您可以記錄錯誤、通知管理者，或者採取適當的回應措施
				// 以下是一個簡單的例子，您可以根據實際需求進行調整

				Console.WriteLine("發生錯誤：" + ex.Message);
				return StatusCode(500, "內部伺服器錯誤，請稍後再試。");
			}
		}

		[HttpPost("ResetPassword")]
		public async Task<ActionResult<string>> ResetPassword(ResetPasswordDTO dto)
		{
			var member = await _context.Members
				.SingleOrDefaultAsync(m => m.Id == dto.MemberId && m.ConfirmCode == dto.ConfirmCode);

			if (member == null)
			{
				return BadRequest("找不到對應的會員紀錄");
			}

			var hashOrigPwd = HashUtility.ToSHA256(dto.CreatePassword, "!@#$$DGTEGYT");

			if (dto.CreatePassword != dto.ConfirmPassword)
			{
				return BadRequest("兩次輸入的密碼不相符，請重新確認。");
			}

			member.Password = hashOrigPwd;
			member.ConfirmCode = null;
			await _context.SaveChangesAsync();

			return Ok();
		}


		[HttpPost("ChangePassword")]
		public async Task<ActionResult<string>> ChangePassword(ChangePasswordDTO dto)
		{
			var account = HttpContext.User.FindFirstValue("MembersAccount");
			var hashOrigPwd = HashUtility.ToSHA256(dto.OriginalPassword, "!@#$$DGTEGYT");
			var member = await _context.Members
				.SingleOrDefaultAsync(m => m.Account == account && m.Password == hashOrigPwd);

			if (member == null)
			{
				return BadRequest("找不到對應的會員紀錄");
			}

			var hashPwd = HashUtility.ToSHA256(dto.CreatePassword, "!@#$$DGTEGYT");

			if (dto.CreatePassword != dto.ConfirmPassword)
			{
				return BadRequest("兩次輸入的密碼不相符，請重新確認。");
			}

			member.Password = hashPwd;
			await _context.SaveChangesAsync();

			return Ok();
		}


		private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }

	}
}
