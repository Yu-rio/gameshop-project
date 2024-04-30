using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<GenreController>
        [HttpGet("GetGenres")]
        public IEnumerable<Genre> Get()
        {
            var genres = new GenreDB().Read();
            return genres;
        }

        // GET api/<GenreController>/5
        [HttpGet("GetGenreById")]
        public Genre Get(string id)
        {
            return new GenreDB().GetById(id);
        }

        // POST api/<GenreController>
        [HttpPost(Name = "NewGenre")]
        public void Post(string genreId, string genreName, string categoryId)
        {
            new GenreDB().Create(genreId, genreName, categoryId);
        }

        // PUT api/<GenreController>/5
        [HttpPut(Name = "UpdateGenre")]
        public void Put(string genreId, string genreName, string categoryId)
        {
            new GenreDB().Update(genreId, genreName, categoryId);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete(Name = "Genre/{id}")]
        public void Delete(string id)
        {
            new GenreDB().Delete(id);
        }
    }
}
