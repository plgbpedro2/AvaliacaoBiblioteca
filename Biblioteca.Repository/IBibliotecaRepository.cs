using System.Threading.Tasks;
using Biblioteca.Domain;

namespace Biblioteca.Repository
{

    public interface IBibliotecaRepository
    {
        
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;


        Task<bool> SaveChangesAsync();

        Task<Livro[]> GetAllLivroAsync();        
        Task<Livro[]> GetAllLivroAsyncByAutor(string tema);
        Task<Livro[]> GetAllLivroAsyncById(int id);
        
    }

}