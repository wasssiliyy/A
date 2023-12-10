using System.Threading.Tasks;

namespace A.Services.Abatract
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
