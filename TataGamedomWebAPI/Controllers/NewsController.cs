using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.DTOs;
using TataGamedomWebAPI.Models.DTOs.Members;
using TataGamedomWebAPI.Models.DTOs.News;
using TataGamedomWebAPI.Models.EFModels;

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
		public async Task<ActionResult<NewsListDto>> GetNews(string? keyword,int page = 1,int pageSize = 9)
        {
          if (_context.News == null)
          {
              return NotFound();
          }
       //  var news = await _context.News.ToListAsync();
            using (var conn = _context.Database.GetDbConnection())
            {
                string sql = @"SELECT n.Id, n.Title, n.ScheduleDate, b.Name AS BackendMemberName,ncc.Name as NewsCategoryName,
            COUNT(nv.MemberId) AS ViewCount, COUNT(nl.MemberId) AS LikeCount, n.ActiveFlag
            FROM news AS n
            JOIN BackendMembers AS b ON b.Id = n.BackendMemberId 
			LEFT JOIN NewsCategoryCodes AS ncc ON ncc.Id = n.NewsCategoryId
            LEFT JOIN GameClassificationsCodes AS gc ON gc.Id = n.GamesId
            LEFT JOIN NewsViews AS nv ON nv.NewsId = n.Id
            LEFT JOIN NewsLikes AS nl ON nl.NewsId = n.Id
			GROUP BY n.Id, n.Title, n.ScheduleDate, b.Name, gc.Name, n.ActiveFlag,ncc.Name";

				if (!string.IsNullOrEmpty(keyword))
				{
					sql += $@"WHERE n,Title LIKE '%{keyword}%' LIKE '%{keyword}%'";
				}
                var news = await conn.QueryAsync<NewsDto>(sql);

				int totalCount = news.Count(); //總共幾筆
												   //int pageSize = 9;  //每頁9筆資料
				int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize); //計算出共幾頁 

                news = news.Skip(pageSize * (page - 1)).Take(pageSize);

				return new NewsListDto { News =  news,TotalPage = totalPages };
			}

        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
          if (_context.News == null)
          {
              return NotFound();
          }
            var news = await _context.News.AsNoTracking().FirstOrDefaultAsync(n=>n.Id == id);

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

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<News>> PostNews(News news)
        //{
        //  if (_context.News == null)
        //  {
        //      return Problem("Entity set 'AppDbContext.News'  is null.");
        //  }
        //    _context.News.Add(news);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNews", new { id = news.Id }, news);
        //}

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
