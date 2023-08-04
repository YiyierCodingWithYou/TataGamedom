using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs.Cart;
using TataGamedomWebAPI.Models.DTOs.Shop;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
		//public async Task<ActionResult<CartDTO>> GetCart(string? account)
		//{
		//	account = HttpContext.User.FindFirstValue(ClaimTypes.Name);
		//	var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);

		//	if (user == null)
		//	{
		//		return NotFound();
		//	}
  //          var currentTime = DateTime.Now;
		//	var cartItems = await _context.Carts
		//                    .Where(c => c.MemberId == user.Id)
		//                    .Select(c => new CartItemDTO
		//                    {
		//	                    Product = new ProductsDTO
		//	                    {
		//		                    Id = c.Product.Id,
		//		                    Index = c.Product.Index,
		//		                    IsVirtual = c.Product.IsVirtual,
		//		                    Price = c.Product.Price,
		//		                    SpecialPrice = c.CouponsProducts.Any(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime)
		//							                    ? (int)Math.Round(c.CouponsProducts
		//								                    .Select(c => c.Coupon.DiscountTypeId == 1
		//									                    ? c.Price * (c.Coupon.Discount / 100.0)
		//									                    : (c.Coupon.DiscountTypeId == 2
		//										                    ? c.Price - c.Coupon.Discount
		//										                    : c.Price))
		//								                    .FirstOrDefault(), 1)
		//							                    : p.Price,
		//		                    GamePlatformName = _context.GamePlatformsCodes.FirstOrDefault(gp => gp.Id == c.Product.GamePlatformId)?.Name,
		//		                    //Score = c.Product.Score,
		//		                    SaleDate = c.Product.SaleDate,
		//		                    ChiName = c.Product.Game.ChiName,
		//		                    //EngName = c.Product.EngName,
		//		                    //IsRestrict = c.Product.IsRestrict,
		//		                    GameCoverImg = c.Product.Game.GameCoverImg,
		//		                    //Classification = _context.GameClassificationsCodes
		//		                    //					.Where(gcc => c.Product.Game.GameClassificationGames
		//		                    //									.Any(gcg => gcg.GameClassificationId == gcc.Id))
		//		                    //					.Select(gcc => gcc.Name)
		//		                    //					.ToList()
		//	                    },
		//	                    Qty = c.Quantity
		//                    })
		//                    .ToListAsync();

		//	var cart = new CartDTO
		//	{
		//		Id = user.Id,
		//		MemberId = user.Id,
		//		CartItems = cartItems
		//	};

		//	return cart;
		//}

		// GET: api/Carts/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
          if (_context.Carts == null)
          {
              return NotFound();
          }
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
          if (_context.Carts == null)
          {
              return Problem("Entity set 'AppDbContext.Carts'  is null.");
          }
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
