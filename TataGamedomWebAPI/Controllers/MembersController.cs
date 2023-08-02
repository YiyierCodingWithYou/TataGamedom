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
		[HttpPost("Login")]
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
                };

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
				return "ok";
			}

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
		[Authorize]
		[HttpGet("{id}")]
        public async Task<ActionResult<MembersDto>> GetMember(int id)
        {
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
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(RegisterDto registerDto)
		{
          if (_context.Members == null)
          {
              return Problem("Entity set 'AppDbContext.Members'  is null.");
          }

			Member member = new Member
			{ 
                Id = registerDto.Id,
                Name = registerDto.Name,
                Account = registerDto.Account,
                Password = registerDto.Password,
                Birthday = registerDto.Birthday,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                RegistrationDate = DateTime.Now,
                IconImg = registerDto.IconImg,
                IsConfirmed = false,
                ConfirmCode = registerDto.ConfirmCode,
                ActiveFlag = true
            };
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
