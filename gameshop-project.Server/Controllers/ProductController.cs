using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet("GetProducts")]
        public IEnumerable<Product> Get()
        {
            var products = new ProductDB().Read();
            return products;
        }

        // GET: api/<ProductController>
        [HttpGet("GetProductsByCategory")]
        public IEnumerable<Product> GetByCategoryId(string categoryId)
        {
            var products = new ProductDB().GetByCategory(categoryId);
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductById")]
        public Product Get(string id)
        {
            return new ProductDB().GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost(Name = "NewProduct")]
        public void Post(string productId, string title, string trailerLink, int? quantity, float price, string content, string categoryId, string publisherId, string genreId, string platformId)
        {
            new ProductDB().Create(productId, title, trailerLink, quantity, price, content, categoryId, publisherId, genreId, platformId);
        }

        // PUT api/<ProductController>/5
        [HttpPut(Name = "UpdateProduct")]
        public void Put(string productId, string title, string trailerLink, int? quantity, float price, string content, string categoryId, string publisherId, string genreId, string platformId)
        {
            new ProductDB().Update(productId, title, trailerLink, quantity, price, content, categoryId, publisherId, genreId, platformId);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete(Name = "Product/{id}")]
        public void Delete(string id)
        {
            new ProductDB().Delete(id);
        }
    }
}
