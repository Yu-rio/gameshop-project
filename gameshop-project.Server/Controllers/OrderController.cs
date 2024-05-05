using ClassLibraryGameShop;
using gameshop_project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet("GetOrders")]
        public IEnumerable<Order> Get()
        {
            var orders = new OrderDB().Read();
            return orders;
        }

        // GET: api/<OrderController>
        [HttpGet("GetOrdersByCustomerId")]
        public IEnumerable<Order> GetByCustomerId(string customerId)
        {
            var orders = new OrderDB().GetByCustomerId(customerId);
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("GetOrderById")]
        public Order Get(string id)
        {
            return new OrderDB().GetById(id);
        }

        // POST api/<OrderController>
        [HttpPost(Name = "NewOrder")]
        public void Post([FromBody] OrderModel order)
        {
            DateTime now = DateTime.Now;
            new OrderDB().Create(order.orderId, now, order.sum, order.status, order.deliveryId, order.customerId, order.transactionId);
        }

        // PUT api/<OrderController>/5
        [HttpPut(Name = "UpdateOrder")]
        public void Put([FromBody] OrderModel order)
        {
            DateTime now = DateTime.Now;
            new OrderDB().Update(order.orderId, now, order.sum, order.status, order.deliveryId, order.customerId, order.transactionId);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete(Name = "Order/{id}")]
        public void Delete(string id)
        {
            new OrderDB().Delete(id);
        }
    }
}
