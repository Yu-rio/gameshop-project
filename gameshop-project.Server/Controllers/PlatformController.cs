using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        // GET: api/<PlatformController>
        [HttpGet("GetPlatforms")]
        public IEnumerable<Platform> Get()
        {
            var platforms = new PlatformDB().Read();
            return platforms;
        }

        // GET api/<PlatformController>/5
        [HttpGet("GetPlatformById")]
        public Platform Get(string id)
        {
            return new PlatformDB().GetById(id);
        }

        // POST api/<PlatformController>
        [HttpPost(Name = "NewPlatform")]
        public void Post(string platformId, string platformName)
        {
            new PlatformDB().Create(platformId, platformName);
        }

        // PUT api/<PlatformController>/5
        [HttpPut(Name = "UpdatePlatform")]
        public void Put(string platformId, string platformName)
        {
            new PlatformDB().Update(platformId, platformName);
        }

        // DELETE api/<PlatformController>/5
        [HttpDelete(Name = "Platform/{id}")]
        public void Delete(string id)
        {
            new PlatformDB().Delete(id);
        }
    }
}
