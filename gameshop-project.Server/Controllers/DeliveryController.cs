using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        // GET: api/<DeliveryController>
        [HttpGet("GetDeliveries")]
        public IEnumerable<Delivery> Get()
        {
            var deliveries = new DeliveryDB().Read();
            return deliveries;
        }

        // GET api/<DeliveryController>/5
        [HttpGet("GetDeliveryById")]
        public Delivery Get(string id)
        {
            return new DeliveryDB().GetById(id);
        }

        // POST api/<DeliveryController>
        [HttpPost(Name = "NewDelivery")]
        public void Post(string deliveryId, string name, string phoneNumber, string status)
        {
            new DeliveryDB().Create(deliveryId, name, phoneNumber, status);
        }

        // PUT api/<DeliveryController>/5
        [HttpPut(Name = "UpdateDelivery")]
        public void Put(string deliveryId, string name, string phoneNumber, string status)
        {
            new DeliveryDB().Update(deliveryId, name, phoneNumber, status);
        }

        // DELETE api/<DeliveryController>/5
        [HttpDelete(Name = "Delivery/{id}")]
        public void Delete(string id)
        {
            new CategoryDB().Delete(id);
        }
    }
}
