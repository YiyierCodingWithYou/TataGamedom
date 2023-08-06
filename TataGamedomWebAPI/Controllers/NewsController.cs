using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.DTOs;
using TataGamedomWebAPI.Models.DTOs.Members;
using TataGamedomWebAPI.Models.DTOs.News;
using TataGamedomWebAPI.Models.EFModels;
using Microsoft.AspNetCore.Identity;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

		// GET: api/News
		[HttpGet]
        public async Task<ActionResult<NewsListDto>> GetNews(string? keyword, string? gamesCategory ,int page = 1, int pageSize = 10)
        {
            if (_context.News == null)
            {
                return NotFound();
            }

            using (var conn = _context.Database.GetDbConnection())
            {
                string sql = @"SELECT n.Id, n.Title, n.Content, n.ScheduleDate, b.Name AS BackendMemberName, ncc.Name as NewsCategoryName,
                              COUNT(nv.MemberId) AS ViewCount, COUNT(nl.MemberId) AS LikeCount, n.ActiveFlag,gc.Name
                              FROM news AS n
                              JOIN BackendMembers AS b ON b.Id = n.BackendMemberId 
                              LEFT JOIN NewsCategoryCodes AS ncc ON ncc.Id = n.NewsCategoryId
                              LEFT JOIN GameClassificationsCodes AS gc ON gc.Id = n.GamesId
                              LEFT JOIN NewsViews AS nv ON nv.NewsId = n.Id
                              LEFT JOIN NewsLikes AS nl ON nl.NewsId = n.Id";

				if (!string.IsNullOrEmpty(keyword) || !string.IsNullOrEmpty(gamesCategory))
				{
					sql += " WHERE ";

					if (!string.IsNullOrEmpty(keyword))
					{
						sql += "n.Title LIKE @Keyword OR CONVERT(nvarchar(19), n.ScheduleDate, 120) LIKE @Keyword OR b.Name LIKE @Keyword OR gc.Name LIKE @Keyword";
					}

					if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(gamesCategory))
					{
						sql += " AND ";
					}

					if (!string.IsNullOrEmpty(gamesCategory))
					{
						sql += "gc.Name LIKE @GamesCategory";
					}
				}

				sql += " GROUP BY n.Id, n.Title, n.Content,n.ScheduleDate, b.Name, gc.Name, n.ActiveFlag, ncc.Name";

                var queryParams = new { Keyword = $"%{keyword}%" , GamesCategory = $"%{gamesCategory}%" };
                var news = await conn.QueryAsync<NewsDto>(sql, queryParams);

                int totalCount = news.Count();
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                news = news.Skip(pageSize * (page - 1)).Take(pageSize);

                return new NewsListDto { News = news, TotalPage = totalPages };
            }
        }


        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetSingleNews(int id)
        {
            if (_context.News == null)
            {
                return NotFound();
            }
            using (var conn = _context.Database.GetDbConnection())
            {
                string sql = @"SELECT n.Id, n.Title, n.Content, n.ScheduleDate, b.Name AS BackendMemberName, ncc.Name as NewsCategoryName,gc.Name,
                              COUNT(nv.MemberId) AS ViewCount, COUNT(nl.MemberId) AS LikeCount, n.ActiveFlag
                              FROM news AS n
                              JOIN BackendMembers AS b ON b.Id = n.BackendMemberId 
                              LEFT JOIN NewsCategoryCodes AS ncc ON ncc.Id = n.NewsCategoryId
                              LEFT JOIN GameClassificationsCodes AS gc ON gc.Id = n.GamesId
                              LEFT JOIN NewsViews AS nv ON nv.NewsId = n.Id
                              LEFT JOIN NewsLikes AS nl ON nl.NewsId = n.Id
							  where n.id = @Id
							  GROUP BY n.Id, n.Title, n.Content,n.ScheduleDate, b.Name, gc.Name, n.ActiveFlag, ncc.Name";

                var news =  conn.QueryFirstOrDefault<NewsDto>(sql, new { Id = id });

                if (news == null )
                {
                    return NotFound();
                }

                // 查詢留言
                string sqlcomments = @"SELECT  NewsComments.[Id]
      ,[NewsId]
      ,[Content]
      ,[Time]
      ,[MemberID]
      ,NewsComments.[ActiveFlag]
      ,[DeleteDatetime]
      ,[DeleteMemberId]
      ,[DeleteBackendMemberId]
	  ,M.Name
  FROM [Tatagamedom].[dbo].[NewsComments]
  left join Members as M on M.ID = NewsComments.MemberID
 where NewsComments.newsid = @Id and NewsComments.ActiveFlag = 1
ORDER BY Time DESC";
                var comments = await conn.QueryAsync<NewsCommentsDTO>(sqlcomments, new { Id = id });

              
				news.NewsComments = comments;

				var memberId = 1;
				if(!string.IsNullOrEmpty(User.FindFirstValue("Membersid")))
				{
					memberId = int.Parse(User.FindFirstValue("Membersid"));
				}

				// 點閱+1
				string newsviews = @"insert NewsViews(NewsId, MemberId, ViewTime)
values(@NewsId, @MemberId, getdate())";
//				string newsviews = @"insert NewsViews(NewsId, MemberId, ViewTime)
//values(1, 1, getdate())";

				var views = await conn.QueryAsync<NewsViewsDTO>(newsviews, new { NewsId = id ,MemberId = memberId});
				

				return Ok(news);
			}
		}


		[HttpGet("HotNews")]
		public async Task<ActionResult<News>> GetHotNews(int id)
		{
			if (_context.News == null)
			{
				return NotFound();
			}
			var news = await _context.News.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);

			if (news == null)
			{
				return NotFound();
			}

			return news;
		}

		//// PUT: api/News/5
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutNews(int id, News news)
		//{
		//    if (id != news.Id)
		//    {
		//        return BadRequest();
		//    }

		//    _context.Entry(news).State = EntityState.Modified;

		//    try
		//    {
		//        await _context.SaveChangesAsync();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!NewsExists(id))
		//        {
		//            return NotFound();
		//        }
		//        else
		//        {
		//            throw;
		//        }
		//    }

		//    return NoContent();
		//}

		//POST: api/News
		//To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[Authorize]
		[HttpPost("{newsId}/Comment")]
        public async Task<ActionResult<NewsComment>> PostNewsComment(int newsId, NewsCommentsDTO newsCommentsDTO)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'AppDbContext.News'  is null.");
            }

			var memberId = HttpContext.User.FindFirstValue("Membersid");

			NewsComment newsComment = new NewsComment
            {
                NewsId = newsId,
                MemberId = int.Parse(memberId),
                Content = newsCommentsDTO.Content,
                ActiveFlag = true,
                Time = DateTime.Now
			};
            _context.NewsComments.Add(newsComment);
            await _context.SaveChangesAsync();

            return Ok("成功留言");
		}

		[Authorize]
		[HttpPost("{newsId}/Like")]
		public async Task<ActionResult<NewslikesDTO>> PostNewsLike(int newsId, NewslikesDTO newslikesDTO)
		{
			if (_context.News == null)
			{
				return Problem("Entity set 'AppDbContext.News'  is null.");
			}

			var memberId = HttpContext.User.FindFirstValue("Membersid");

			NewsLike newslike = new NewsLike
			{
				NewsId = newsId,
				MemberId = int.Parse(memberId),
				Time = DateTime.Now
			};
			_context.NewsLikes.Add(newslike);
			await _context.SaveChangesAsync();

			return Ok("成功按讚");
		}

		[Authorize]
		[HttpDelete("{newsId}/Like")]
		public async Task<ActionResult<NewslikesDTO>> DeleteNewsLike(int newsId, NewslikesDTO newslikesDTO)
		{
			if (_context.News == null)
			{
				return Problem("Entity set 'AppDbContext.News'  is null.");
			}
			var memberId = HttpContext.User.FindFirstValue("Membersid");
			//var memberId = int.Parse(User.FindFirstValue("Membersid"));


			using (var conn = _context.Database.GetDbConnection())
			{
				string sql = @"DELETE 
FROM NewsLikes
WHERE NewsId =　@newsId
AND MemberId = @memberId";

				var news = conn.QueryFirstOrDefault<NewslikesDTO>(sql, new { newsId = newsId, memberId = memberId });
			}
			return Ok("取消按讚");
		}

		//// DELETE: api/News/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteNews(int id)
		//{
		//    if (_context.News == null)
		//    {
		//        return NotFound();
		//    }
		//    var news = await _context.News.FindAsync(id);
		//    if (news == null)
		//    {
		//        return NotFound();
		//    }

		//    _context.News.Remove(news);
		//    await _context.SaveChangesAsync();

		//    return NoContent();
		//}

		private bool NewsExists(int id)
        {
            return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
