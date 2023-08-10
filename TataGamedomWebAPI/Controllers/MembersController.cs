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
			else
			{
				//string memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
				//string memberName = HttpContext.User.FindFirstValue("FullName");
				var claims = new List<Claim>
				{
                    //這邊可以自定義
					//new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), //抓ID
					new Claim(ClaimTypes.Name, user.Account),//抓帳號
					new Claim("MembersName", user.Name),//抓名字
                    new Claim("Membersid",user.Id.ToString())//抓ID欄位
                };


				//var authenticationProperties = new AuthenticationProperties();
				//authenticationProperties.IsPersistent = true;
				//authenticationProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30);
				//authenticationProperties.AllowRefresh = true;

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
				//HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties);

				return Ok();

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

		// GET: api/Members/5

		[HttpGet("{id}")]
        public async Task<ActionResult<MembersDto>> GetMember(int id)
        {
            //var userId = HttpContext.User.FindFirstValue("MembersName");
            //var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);

			if (_context.Members == null)
          {
              return NotFound();
          }
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            var memberDto = new MembersDto
            {
                Id=member.Id,
                Name=member.Name,
               // Account = member.Account,
                //Password = member.Password,
                Birthday = member.Birthday,
                Email = member.Email,
                Phone = member.Phone,
                IconImg = member.IconImg,
                //ActiveFlag = member.ActiveFlag,
               // LastOnlineTime = member.LastOnlineTime,     
            };
			return memberDto;
		}

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, MembersDto membersDto)
        {
            if (id != membersDto.Id)
            {
                return BadRequest();
            }

			var member = await _context.Members.FindAsync(id);

			if (member == null)
			{
				return NotFound();
			}

            member.Id = membersDto.Id;
            member.Name = membersDto.Name;
            //member.Account = membersDto.Account;
          //  member.Password = membersDto.Password;
            member.Birthday = membersDto.Birthday;
            member.Email = membersDto.Email;
            member.Phone = membersDto.Phone;
            member.IconImg = membersDto.IconImg;
            //member.ActiveFlag = membersDto.ActiveFlag;
			//member.LastOnlineTime = membersDto.LastOnlineTime;
			

			//_context.Entry(membersDto).State = EntityState.Modified;

			try
			{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AllowCookie")]
        [HttpPost("Register")]
        public async Task<ActionResult<Member>> PostMember(RegisterDto registerDto)
		{
          if (_context.Members == null)
          {
              return Problem("Entity set 'AppDbContext.Members'  is null.");
          }

            if (await _context.Members.AnyAsync(m => m.Account == registerDto.Account))
            {
				return BadRequest("此帳號已經有人使用過囉");
			}

			if (registerDto.Password != registerDto.CheckPassword)
			{
				return BadRequest("兩次輸入的密碼不相符，請重新確認。");
			}

			var hashOrigPwd = HashUtility.ToSHA256(registerDto.Password, "!@#$$DGTEGYT");
			//var hashCheckPwd = HashUtility.ToSHA256(registerDto.CheckPassword, "!@#$$DGTEGYT");
			var pocha = "POCHA.jpg";
			//驗證用不寫入SQL
			registerDto.CheckPassword = null;

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
                ConfirmCode = registerDto.ConfirmCode,
                ActiveFlag = true
			};
            if (registerDto.IconImg == null)
            {
                member.IconImg = pocha;
            }

			await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        //// DELETE: api/Members/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMember(int id)
        //{
        //    if (_context.Members == null)
        //    {
        //        return NotFound();
        //    }
        //    var member = await _context.Members.FindAsync(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Members.Remove(member);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }

	}
}
