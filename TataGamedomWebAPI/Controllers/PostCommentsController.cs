using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Infra;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private SimpleHelper _simpleHelper;

        public PostCommentsController(AppDbContext context)
        {
            _context = context;
            _simpleHelper = new SimpleHelper(context);
        }

        //// GET: api/PostComments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PostComment>>> GetPostComments()
        //{
        //  if (_context.PostComments == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.PostComments.ToListAsync();
        //}

        //// GET: api/PostComments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PostComment>> GetPostComment(int id)
        //{
        //  if (_context.PostComments == null)
        //  {
        //      return NotFound();
        //  }
        //    var postComment = await _context.PostComments.FindAsync(id);

        //    if (postComment == null)
        //    {
        //        return NotFound();
        //    }

        //    return postComment;
        //}

        // PUT: api/PostComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> EditPostComment(int id, PostComment postComment)
        {
            if (id != postComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(postComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCommentExists(id))
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



        // POST: api/PostComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostComment>> CreartePostComment(PostComment postComment)
        {
          if (_context.PostComments == null)
          {
              return Problem("Entity set 'AppDbContext.PostComments'  is null.");
          }
            _context.PostComments.Add(postComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostComment", new { id = postComment.Id }, postComment);
        }

        // DELETE: api/PostComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostComment(int id)
        {
            if (_context.PostComments == null)
            {
                return NotFound();
            }
            var postComment = await _context.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return NotFound();
            }

            _context.PostComments.Remove(postComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostCommentExists(int id)
        {
            return (_context.PostComments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
