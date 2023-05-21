using CoreWebApiAngularCapstoneProject.DAL;
using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet("getcartlist")]
        public async Task<List<Cart>> GetCartsAsync()
        {
            try
            {
                return await cartService.GetCartListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("getcartbyid")]
        public async Task<IEnumerable<Cart>> GetCartByIdAsync(int CartId)
        {
            try
            {
                var response = await cartService.GetCartByIdAsync(CartId);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addcart")]

        public async Task<IActionResult> AddCart(Cart cart)
        {
            if (cart == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await cartService.AddCartAsync(cart);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

  
        [HttpDelete("deletecartbyid")]

        public async Task<IActionResult> DeleteCart(int CartId)
        {
            if (CartId == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await cartService.DeleteCartAsync(CartId);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
