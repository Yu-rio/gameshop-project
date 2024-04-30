using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        // GET: api/<ShipmentController>
        [HttpGet("GetShipments")]
        public IEnumerable<Shipment> Get()
        {
            var shipments = new ShipmentDB().Read();
            return shipments;
        }

        // GET api/<ShipmentController>/5
        [HttpGet("GetShipmentById")]
        public Shipment Get(string id)
        {
            return new ShipmentDB().GetById(id);
        }

        // POST api/<ShipmentController>
        [HttpPost(Name = "NewShipment")]
        public void Post(string shipmentId, DateTime dateAndTime, float? sum, string warehouseId, string supplierId, string transactionId)
        {
            new ShipmentDB().Create(shipmentId, dateAndTime, sum, warehouseId, supplierId, transactionId);
        }

        // PUT api/<ShipmentController>/5
        [HttpPut(Name = "UpdateShipment")]
        public void Put(string shipmentId, DateTime dateAndTime, float? sum, string warehouseId, string supplierId, string transactionId)
        {
            new ShipmentDB().Update(shipmentId, dateAndTime, sum, warehouseId, supplierId, transactionId);
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete(Name = "Shipment/{id}")]
        public void Delete(string id)
        {
            new ShipmentDB().Delete(id);
        }
    }
}
