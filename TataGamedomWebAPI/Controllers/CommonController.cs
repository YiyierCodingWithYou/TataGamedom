using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
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
		[HttpGet("IsLogined")]
		public async Task<ActionResult> IsLogined()
		{
			var account = HttpContext.User.FindFirstValue("MembersAccount");
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);

			if (user == null)
			{
				return BadRequest(new { IsLogined = false});
			}
			else
			{
				return Ok(new { IsLogined = true, Account = user.Account , Name = user.Name });
			}
		}


		private string GetFullUrl(string path)
		{
			var request = _httpContextAccessor.HttpContext.Request;
			return $"{request.Scheme}://{request.Host}{request.PathBase}/{path}";
		}

	}
}
