using A.Entities;
using A.Services.Concrete;

namespace A.Services.Abatract
{
    public interface IGetMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task Get();
    }
}
