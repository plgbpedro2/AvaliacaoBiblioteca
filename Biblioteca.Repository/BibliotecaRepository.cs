using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository
{
    public class BibliotecaRepository : IBibliotecaRepository
    {   

        public readonly BibliotecaContext _context;

        public BibliotecaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; // caso a funcao desejada funcionar vai retornar > 0 
        }

        public async Task<Livro[]> GetAllLivroAsync()
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.OrderBy(l => l.Titulo);

            return await query.ToArrayAsync();
            
        }

        public async Task<Livro[]> GetAllLivroAsyncByAutor(string autor)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.OrderBy(l => l.Titulo)
                    .Where(l => l.Autor.ToLower().Contains(autor.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Livro[]> GetAllLivroAsyncById(int id)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Where(l => l.Id == id);

            return await query.ToArrayAsync();
        }
    }
}