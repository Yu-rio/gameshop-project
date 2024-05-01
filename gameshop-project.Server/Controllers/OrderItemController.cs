using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        // GET: api/<OrderItemController>
        [HttpGet("GetOrderItems")]
        public IEnumerable<OrderItem> Get()
        {
            var orderItems = new OrderItemDB().Read();
            return orderItems;
        }
        // GET: api/<OrderItemController>
        [HttpGet("GetOrderItemsByOrderId")]
        public IEnumerable<OrderItem> GetByOrderId(string orderId)
        {
            var orderItems = new OrderItemDB().GetByOrderId(orderId);
            return orderItems;
        }
        // GET api/<OrderItemController>/5
        [HttpGet("GetOrderItemByProductIdAndOrderId")]
        public OrderItem Get(string productId, string orderId)
        {
            return new OrderItemDB().GetOrderItemByProductIdAndOrderId(productId, orderId);
        }

        // POST api/<OrderItemController>
        [HttpPost(Name = "NewOrderItem")]
        public void Post(float? price, int? quantity, string productId, string orderId)
        {
            new OrderItemDB().Create(price, quantity,  productId, orderId);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut(Name = "UpdateOrderItem")]
        public void Put(float? price, int? quantity, string productId, string orderId)
        {
            new OrderItemDB().Create(price, quantity, productId, orderId);
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete(Name = "OrederItem/{productId}/{orderId}")]
        public void Delete(string productId, string orderId)
        {
            new OrderItemDB().Delete(productId, orderId);
        }
    }
}
