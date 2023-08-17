using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services;
using System.Security.Claims;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs.Common;
using TataGamedomWebAPI.Models.DTOs.Members;

namespace TataGamedomWebAPI.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class CommonController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly AppDbContext _context;

		public CommonController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_context = context;
		}


		[HttpPost("uploadImage/{folderName}")]

		public async Task<string> UploadImage(string folderName, IFormFile file)
		{
			if (file == null)
			{
				return null;
			}
			var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Uploads", folderName);

			var relativePath = Path.Combine("Files", "Uploads", folderName, fileName).Replace("\\", "/"); ;

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			var filePath = Path.Combine(folderPath, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return GetFullUrl(relativePath);
		}

		[EnableCors("AllowCookie")]
		[HttpGet("IsLoggedIn")]
		public async Task<ActionResult> IsLoggedIn()
		{
			var account = HttpContext.User.FindFirstValue("MembersAccount");
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);
			

			if (user == null)
			{
				return BadRequest(new { IsLogined = false });
			}
			else
			{
				var currentDate = DateTime.Now;
				var age = currentDate.Year - user.Birthday.Year;
				if (currentDate.Month < user.Birthday.Month || (currentDate.Month == user.Birthday.Month && currentDate.Day < user.Birthday.Day))
				{
					age--; // 如果生日尚未到來，則減少一歲
				}
				return Ok(new { IsLoggedIn = true, Account = user.Account , Name = user.Name ,Age = age});
			}
		}

		[HttpGet("Search/BoardOrAccount/{keyword}")]
		public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchBoardOrAccount(string keyword)
		{
			List<SearchResultDto> result = new List<SearchResultDto>();

			var boardDevide = new SearchResultDto()
			{
				Name = "---Board---",
				Type =  string.Empty,
				IconUrl = null,
				Param = null
			};

			var boards = await _context.Boards.Where(b => b.Name.Contains(keyword)).Select(b => new SearchResultDto()
			{
				Name = b.Name,
				Type = "Board",
				IconUrl = GetFullUrl("Files/Icons/tataBoardIcon.jpg"),
				Param = b.Id.ToString()
			}).ToListAsync();

			var memberDevide = new SearchResultDto()
			{
				Name = "---Member---",
				Type = string.Empty,
				IconUrl = null,
				Param = null
			};

			var members = await _context.Members.Where(m => m.Name.Contains(keyword) || m.Account.Contains(keyword)).Select(m => new SearchResultDto()
			{
				Name = $"{m.Name} ( {m.Account} )",
				Type = "Member",
				IconUrl = GetFullUrl("Files/Icons/tataUserIcon.jpg"),
				Param = m.Account
			}).ToListAsync();

			var notfound = new SearchResultDto()
			{
				Name = "---查無相關版名或獺獺😢---",
				Type = string.Empty,
				IconUrl = null,
				Param = null
			};

			if(boards.Count != 0 )
			{
			result.Add(boardDevide);
			}
			result.AddRange(boards);
			if(members.Count != 0)
			{
			result.Add(memberDevide);
			}
			result.AddRange(members);
            if (boards.Count == 0 && members.Count==0)
            {
                result.Add(notfound);
            }

            return Ok(result);
		}

		[HttpGet("Search/BoardOrAccount")]
		public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchBoardOrAccount()
		{
			List<SearchResultDto> result = new List<SearchResultDto>();

			var notSelected = new SearchResultDto()
			{
				Name = "尋找「巢穴」或「獺獺」🦦",
				Type = string.Empty,
				IconUrl = null,
				Param = null
			};

			var boardDevide = new SearchResultDto()
			{
				Name = "---Boards---",
				Type = string.Empty,
				IconUrl = null,
				Param = null
			};

			var boards = await _context.Boards.Select(b => new SearchResultDto()
			{
				Name = b.Name,
				Type = "Board",
				IconUrl = GetFullUrl("Files/Icons/tataBoardIcon.jpg"),
				Param = b.Id.ToString()
			}).ToListAsync();

			var memberDevide = new SearchResultDto()
			{
				Name = "---Member---",
				Type = string.Empty,
				IconUrl = null,
				Param = null
			};

			var members = await _context.Members.Select(m => new SearchResultDto()
			{
				Name = $"{m.Name} ( {m.Account} )",
				Type = "Member",
				IconUrl = GetFullUrl("Files/Icons/tataUserIcon.jpg"),
				Param = m.Account
			}).ToListAsync();

			result.Add(notSelected);
			result.Add(boardDevide);
			result.AddRange(boards);
			result.Add(memberDevide);
			result.AddRange(members);

			return Ok(result);
		}


		private string GetFullUrl(string path)
		{
			var request = _httpContextAccessor.HttpContext.Request;
			return $"{request.Scheme}://{request.Host}{request.PathBase}/{path}";
		}

	}
}
