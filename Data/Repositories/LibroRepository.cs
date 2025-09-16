using EF_WEB_API_LIBROS.Data.Models;

namespace EF_WEB_API_LIBROS.Data.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private LibrosDbContext _context;

        public LibroRepository(LibrosDbContext context)
        {
            _context = context;
        }

        public void Create(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libroDeleted = GetById(id);
            if (libroDeleted != null)
            {
                _context.Libros.Remove(libroDeleted);
                _context.SaveChanges();
            }
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public void Update(Libro libro)
        {   
            if (libro != null)
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();
            }
        }
    }
}
