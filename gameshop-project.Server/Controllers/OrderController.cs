using ClassLibraryGameShop;
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

        // GET api/<OrderController>/5
        [HttpGet("GetOrderById")]
        public Order Get(string id)
        {
            return new OrderDB().GetById(id);
        }

        // POST api/<OrderController>
        [HttpPost(Name = "NewOrder")]
        public void Post(string orderId, DateTime orderDate, float sum, string status, string deliveryId, string customerId, string transactionId)
        {
            new OrderDB().Create(orderId, orderDate, sum, status, deliveryId, customerId, transactionId);
        }

        // PUT api/<OrderController>/5
        [HttpPut(Name = "UpdateOrder")]
        public void Put(string orderId, DateTime orderDate, float sum, string status, string deliveryId, string customerId, string transactionId)
        {
            new OrderDB().Update(orderId, orderDate, sum, status, deliveryId, customerId, transactionId);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete(Name = "Order/{id}")]
        public void Delete(string id)
        {
            new OrderDB().Delete(id);
        }
    }
}
