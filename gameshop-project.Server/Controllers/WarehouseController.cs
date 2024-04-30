using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using System;
using TestShop;


namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        // GET: api/<WarehouseController>
        [HttpGet("GetWarehouse")]
        public IEnumerable<Warehouse> Get()
        {
            var warehouses = new WarehouseDB().Read();
            return warehouses;
        }

        // GET api/<WarehouseController>/5
        [HttpGet("GetWarehouseById")]
        public Warehouse Get(string id)
        {
            return new WarehouseDB().GetById(id);
        }

        // POST api/<WarehouseController>
        [HttpPost(Name = "NewWarehouse")]
        public void Post(string warehouseId, string address, string phoneNumber)
        {
            new WarehouseDB().Create(warehouseId, address, phoneNumber);
        }

        // PUT api/<WarehouseController>/5
        [HttpPut(Name = "UpdateWarehouse")]
        public void Put(string productId, string title, string trailerLink, int? quantity, float price, string content, string categoryId, string publisherId, string genreId, string platformId)
        {
            new ProductDB().Update(productId, title, trailerLink, quantity, price, content, categoryId, publisherId, genreId, platformId);
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete(Name = "Warehouse/{id}")]
        public void Delete(string id)
        {
            new WarehouseDB().Delete(id);
        }
    }
}
