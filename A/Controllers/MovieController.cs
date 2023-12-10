using A.Entities;
using A.Services.Abatract;
using A.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net.Http;
using System.Text;

namespace A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGetMovieService _movieService;

        public MovieController(IGetMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]

        public async Task<IEnumerable<Movie>> Get()
        {
            return await _movieService.GetAllMovies();
        }


        [HttpPost]

        public async Task<IActionResult> Add()
        {
            try
            {
                 _movieService.Get();
                return  NoContent();
                //return Ok(await _movieService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
