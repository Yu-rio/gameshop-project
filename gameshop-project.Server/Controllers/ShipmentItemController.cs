using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentItemController : ControllerBase
    {
        // GET: api/<ShipmentItemController>
        [HttpGet("GetShipmentItems")]
        public IEnumerable<ShipmentItem> Get()
        {
            var shipmentItems = new ShipmentItemDB().Read();
            return shipmentItems;
        }

        // GET: api/<ShipmentItemController>
        [HttpGet("GetShipmentItemsByShipmentId")]
        public IEnumerable<ShipmentItem> GetByShipmentId(string shipmentId)
        {
            var shipmentItems = new ShipmentItemDB().GetShipmentItemByShipmentId(shipmentId);
            return shipmentItems;
        }

        // GET api/<ShipmentItemController>/5
        [HttpGet("GetShipmentItemByShipmentIdAndProductId")]
        public ShipmentItem Get(string shipmentId, string productId)
        {
            return new ShipmentItemDB().GetShipmentItemByShipmentIdAndProductId(shipmentId,productId);
        }

        // POST api/<ShipmentItemController>
        [HttpPost(Name = "NewShipmentItem")]
        public void Post(string shipmentId, string productId, int quantity, float? price)
        {
            new ShipmentItemDB().Create(shipmentId, productId, quantity, price);
        }

        // PUT api/<ShipmentItemController>/5
        [HttpPut(Name = "UpdateShipmentItem")]
        public void Put(string shipmentId, string productId, int quantity, float? price)
        {
            new ShipmentItemDB().Update(shipmentId, productId, quantity, price);
        }

        // DELETE api/<ShipmentItemController>/5
        [HttpDelete(Name = "ShipmentItem/{shipmentId}/{productId}")]
        public void Delete(string shipmentId, string productId)
        {
            new ShipmentItemDB().Delete(shipmentId, productId);
        }
    }
}
