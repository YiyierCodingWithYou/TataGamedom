using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TataGamedomWebAPI.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class CommonController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CommonController(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
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

		private string GetFullUrl(string path)
		{
			var request = _httpContextAccessor.HttpContext.Request;
			return $"{request.Scheme}://{request.Host}{request.PathBase}/{path}";
		}

	}
}
