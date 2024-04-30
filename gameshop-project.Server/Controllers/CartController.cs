using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // POST api/<ValuesController>
        [HttpPost(Name = "NewCart")]
        public void Post(string id, DateTime createdAt, string customerId)
        {
            new CartDB().Create(id, createdAt, customerId);
        }

        // PUT api/<ValuesController>/5
        [HttpPut(Name = "UpdateCart")]
        public void Put(string id, DateTime createdAt, string customerId)
        {
            new CartDB().Update(id, createdAt, customerId);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete(Name = "Cart/{id}")]
        public void Delete(string id)
        {
            new CartDB().Delete(id);
        }
    }
}
