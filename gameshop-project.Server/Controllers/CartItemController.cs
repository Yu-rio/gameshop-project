using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        // GET: api/<CartItemController>
        [HttpGet("GetCartItems")]
        public IEnumerable<CartItem> Get()
        {
            var cartItems = new CartItemDB().Read();
            return cartItems;
        }

        // GET api/<CartItemController>/5
        [HttpGet("GetCartItemByProductIdAndCartId")]
        public CartItem Get(string productId, string cartId)
        {
            return new CartItemDB().GetCartItemByProductIdAndCartId(productId, cartId);
        }

        // POST api/<CartItemController>
        [HttpPost(Name = "NewCartItem")]
        public void Post(float? price, int? quantity, string productId, string cartId)
        {
            new CartItemDB().Create(price, quantity, productId, cartId);
        }

        // PUT api/<CartItemController>/5
        [HttpPut(Name = "UpdateCartItem")]
        public void Put(float? price, int? quantity, string productId, string cartId)
        {
            new CartItemDB().Update(price, quantity, productId, cartId);
        }

        // DELETE api/<CartItemController>/5
        [HttpDelete(Name = "CartItem/{productId}/{cartId}")]
        public void Delete(string productId, string cartId)
        {
            new CartItemDB().Delete(productId, cartId);
        }
    }
}
