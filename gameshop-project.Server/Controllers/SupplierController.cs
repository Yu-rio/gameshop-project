using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        // GET: api/<SupplierController>
        [HttpGet("GetSuppliers")]
        public IEnumerable<Supplier> Get()
        {
            var suppliers = new SupplierDB().Read();
            return suppliers;
        }

        // GET api/<SupplierController>/5
        [HttpGet("GetSupplierById")]
        public Supplier Get(string id)
        {
            return new SupplierDB().GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost(Name ="NewSupplier")]
        public void Post(string supplierId, string supplierName, string phoneNumber, string address)
        {
            new SupplierDB().Create(supplierId, supplierName, phoneNumber, address);
        }

        // PUT api/<SupplierController>/5
        [HttpPut(Name = "Supplier/{id}")]
        public void Put(string supplierId, string supplierName, string phoneNumber, string address)
        {
            new SupplierDB().Update(supplierId, supplierName, phoneNumber, address);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete(Name = "Supplier/{id}")]
        public void Delete(string id)
        {
            new SupplierDB().Delete(id);
        }
    }
}
