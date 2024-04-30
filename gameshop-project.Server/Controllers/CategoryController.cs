using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet("GetPlatforms")]
        public IEnumerable<Category> Get()
        {
            var categories = new CategoryDB().Read();
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("GetPlatformById")]
        public Category Get(string id)
        {
            return new CategoryDB().GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost(Name = "NewCategory")]
        public void Post(string id, string name)
        {
            new CategoryDB().Create(id, name);
        }

        // PUT api/<CategoryController>/5
        [HttpPut(Name = "UpdateCategory")]
        public void Put(string id, string name)
        {
            new CategoryDB().Update(id, name);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete(Name = "Category/{id}")]
        public void Delete(string id)
        {
            new CategoryDB().Delete(id);
        }
    }
}
