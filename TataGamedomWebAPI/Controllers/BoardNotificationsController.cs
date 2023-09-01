using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs.Board;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
    [ApiController]
    public class BoardNotificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoardNotificationsController(AppDbContext context)
        {
            _context = context;
        }

		// GET: api/BoardNotifications
		[EnableCors("AllowCookie")]
		[HttpGet]
        public async Task<ActionResult<IEnumerable<BoardNotificationDto>>> GetBoardNotifications()
        {           
			var account = HttpContext.User.FindFirstValue("MembersAccount");
            if (account == null)
            {
                return null;
            }
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);
			if (_context.BoardNotifications == null)
          {
              return NotFound();
          }
            return await _context.BoardNotifications.Where(m=>m.RecipientMemberId==user.Id).Select(n=> new BoardNotificationDto
            {	Id = n.Id,
                RecipientMemberId = n.RecipientMemberId,
                RelationMemberId = n.RelationMemberId,
                RelationPostId = n.RelationPostId,
                Content = n.Content,
                Link = n.Link,
                IsReaded = n.IsReaded,
                CreateTime = n.CreateTime,
                ReadTime = n.ReadTime
            }).OrderByDescending(n=>n.CreateTime).ToListAsync();
        }

        // PUT: api/BoardNotifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[EnableCors("AllowCookie")]
		[HttpPut("{id}")]
        public async Task<IActionResult> PutBoardNotification(int id)
        {
            var boardNotification = await _context.BoardNotifications.FindAsync(id);
            if (boardNotification == null)
            {
				return NotFound();
			}
            try
            {
                boardNotification.IsReaded = true;
                boardNotification.ReadTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardNotificationExists(id))
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

        private bool BoardNotificationExists(int id)
        {
            return (_context.BoardNotifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
