using A.Entities;
using A.Repositories.Abstract;
using A.Services.Abatract;

namespace A.Services.Concrete
{
    public class EFMovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public EFMovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Movie entity)
        {
            await _repository.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task Update(Movie entity)
        {
            _repository.Update(entity);
        }
    }
}
