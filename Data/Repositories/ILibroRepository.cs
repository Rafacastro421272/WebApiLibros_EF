using EF_WEB_API_LIBROS.Data.Models;

namespace EF_WEB_API_LIBROS.Data.Repositories
{
    public interface ILibroRepository
    {
        void Create(Libro libro);
        void Update(Libro libro);
        List<Libro> GetAll();
        Libro? GetById(int id);
        void Delete(int id);
    }
}
