using ClassLibraryGameShop;
using gameshop_project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using TestShop;


namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("GetCarts")]
        public IEnumerable<Cart> Get()
        {
            var carts = new CartDB().Read();
            return carts;
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetCartById")]
        public Cart Get(string id)
        {
            return new CartDB().GetById(id);
        }
        // GET api/<ValuesController>/5
        [HttpGet("GetCartByCustomerId")]
        public Cart GetByCustomerId(string customerId)
        {
            return new CartDB().GetByCustomerId(customerId);
        }

        // POST api/<ValuesController>
        [HttpPost(Name = "NewCart")]
        public void Post([FromBody] CartModel cart)
        {
            DateTime now = DateTime.Now;
            new CartDB().Create(cart.id, now, cart.customerId);
        }

        // PUT api/<ValuesController>/5
        [HttpPut(Name = "UpdateCart")]
        public void Put([FromBody] CartModel cart)
        {
            DateTime now = DateTime.Now;
            new CartDB().Update(cart.id, now, cart.customerId);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete(Name = "Cart/{id}")]
        public void Delete(string id)
        {
            new CartDB().Delete(id);
        }
    }
}
