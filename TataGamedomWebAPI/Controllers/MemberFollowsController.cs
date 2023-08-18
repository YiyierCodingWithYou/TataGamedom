using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberFollowsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MemberFollowsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MemberFollows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberFollow>>> GetMemberFollows()
        {
          if (_context.MemberFollows == null)
          {
              return NotFound();
          }
            return await _context.MemberFollows.ToListAsync();
        }

        // GET: api/MemberFollows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberFollow>> GetMemberFollow(int id)
        {
          if (_context.MemberFollows == null)
          {
              return NotFound();
          }
            var memberFollow = await _context.MemberFollows.FindAsync(id);

            if (memberFollow == null)
            {
                return NotFound();
            }

            return memberFollow;
        }

        // PUT: api/MemberFollows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberFollow(int id, MemberFollow memberFollow)
        {
            if (id != memberFollow.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberFollow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberFollowExists(id))
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

        // POST: api/MemberFollows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemberFollow>> PostMemberFollow(MemberFollow memberFollow)
        {
          if (_context.MemberFollows == null)
          {
              return Problem("Entity set 'AppDbContext.MemberFollows'  is null.");
          }
            _context.MemberFollows.Add(memberFollow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberFollow", new { id = memberFollow.Id }, memberFollow);
        }

        // DELETE: api/MemberFollows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberFollow(int id)
        {
            if (_context.MemberFollows == null)
            {
                return NotFound();
            }
            var memberFollow = await _context.MemberFollows.FindAsync(id);
            if (memberFollow == null)
            {
                return NotFound();
            }

            _context.MemberFollows.Remove(memberFollow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberFollowExists(int id)
        {
            return (_context.MemberFollows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
