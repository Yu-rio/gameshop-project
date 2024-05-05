using ClassLibraryGameShop;
using gameshop_project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using TestShop;

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
        public void Post([FromBody] ProductModel product)
        {
            new ProductDB().Create(product.productId, product.title, product.trailerLink, product.quantity, product.price, product.content, product.categoryId, product.publisherId, product.genreId, product.platformId);
        }

        // PUT api/<ProductController>/5
        [HttpPut(Name = "UpdateProduct")]
        public void Put([FromBody] ProductModel product)
        {
            new ProductDB().Update(product.productId, product.title, product.trailerLink, product.quantity, product.price, product.content, product.categoryId, product.publisherId, product.genreId, product.platformId);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete(Name = "Product/{id}")]
        public void Delete(string id)
        {
            new ProductDB().Delete(id);
        }
    }
}
