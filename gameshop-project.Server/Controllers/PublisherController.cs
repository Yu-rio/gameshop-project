using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        // GET: api/<PublisherController>
        [HttpGet("GetPublishers")]
        public IEnumerable<Publisher> Get()
        {
            var publishers = new PublisherDB().Read();
            return publishers;
        }

        // GET api/<PublisherController>/5
        [HttpGet("GetPublisherById")]
        public Publisher Get(string id)
        {
            return new PublisherDB().GetById(id);
        }

        // POST api/<PublisherController>
        [HttpPost(Name = "NewPublisher")]
        public void Post(string publisherId, string publisherName, string categoryId)
        {
            new PublisherDB().Create(publisherId, publisherName, categoryId);
        }

        // PUT api/<PublisherController>/5
        [HttpPut(Name = "UpdatePublisher")]
        public void Put(string publisherId, string publisherName, string categoryId)
        {
            new PublisherDB().Update(publisherId, publisherName, categoryId);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete(Name = "Publisher/{id}")]
        public void Delete(string id)
        {
            new PublisherDB().Delete(id);
        }
    }
}
