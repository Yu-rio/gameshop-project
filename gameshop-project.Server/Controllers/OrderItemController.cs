using ClassLibraryGameShop;
using gameshop_project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using TestShop;

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
        public void Post([FromBody] OrderItemModel orderItem)
        {
            new OrderItemDB().Create(orderItem.price, orderItem.quantity,  orderItem.productId, orderItem.orderId);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut(Name = "UpdateOrderItem")]
        public void Put([FromBody] OrderItemModel orderItem)
        {
            new OrderItemDB().Create(orderItem.price, orderItem.quantity, orderItem.productId, orderItem.orderId);
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete(Name = "OrederItem/{productId}/{orderId}")]
        public void Delete(string productId, string orderId)
        {
            new OrderItemDB().Delete(productId, orderId);
        }
    }
}
