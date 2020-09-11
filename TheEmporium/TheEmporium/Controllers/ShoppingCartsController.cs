using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheEmporium.Data;
using TheEmporium.Models;
using TheEmporium.Models.DTOs;

namespace TheEmporium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingCartsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ShoppingCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartDto>>> GetShoppingCart()
        {
            var shoppingCarts = await _context.ShoppingCart.ToListAsync();
            var shoppingCartDtos = _mapper.Map<IEnumerable<ShoppingCartDto>>(shoppingCarts);
            return Ok(shoppingCartDtos);
        }

        // GET: api/ShoppingCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDto>> GetShoppingCart(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            var shoppingCartDto = _mapper.Map<ShoppingCartDto>(shoppingCart);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return Ok(shoppingCartDto);
        }

        // PUT: api/ShoppingCarts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCart(int id, ShoppingCartDto shoppingCartDto)
        {

            if (id != shoppingCartDto.Id)
            {
                return BadRequest();
            }

            var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);

            _context.Entry(shoppingCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartExists(id))
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

        // POST: api/ShoppingCarts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> PostShoppingCart(ShoppingCartDto shoppingCartDto)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);
            await _context.ShoppingCart.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCart", new { id = shoppingCart.Id }, shoppingCart);
        }

        // DELETE: api/ShoppingCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingCart>> DeleteShoppingCart(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            _context.ShoppingCart.Remove(shoppingCart);
            await _context.SaveChangesAsync();

            return shoppingCart;
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCart.Any(e => e.Id == id);
        }
    }
}
