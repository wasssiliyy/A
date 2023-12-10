using A.Data;
using A.Entities;
using A.Repositories.Abstract;
using A.Services.Abatract;

namespace A.Repositories.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        private readonly MoviewDbContext _dbContext;

        public EFMovieRepository(MoviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Movie entity)
        {
            try
            {
                _dbContext.Movies.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return _dbContext.Movies;
        }

        public Movie GetById(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }

        public async Task Update(Movie entity)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == entity.Id);
            movie.Title = entity.Title;
            movie.Director = entity.Director;
            movie.ImdbRating = entity.ImdbRating;
            movie.Genre = entity.Genre;
            _dbContext.SaveChangesAsync();
        }
    }
}
