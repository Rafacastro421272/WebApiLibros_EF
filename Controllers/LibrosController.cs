using EF_WEB_API_LIBROS.Data.Models;
using EF_WEB_API_LIBROS.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_WEB_API_LIBROS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private ILibroRepository _libroRepository;

        public LibrosController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_libroRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error interno.");
            }
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro libro)
        {
            try
            {
                if (IsValid(libro)) // Validaciones
                {
                    _libroRepository.Create(libro);
                    return Ok("Libro creado!");
                }
                else
                {
                    return BadRequest("Los datos no son válidos o incompletos!");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        private bool IsValid(Libro libro)
        {
            return !string.IsNullOrWhiteSpace(libro.Isbn) &&
                   !string.IsNullOrWhiteSpace(libro.Nombre) &&
                   !string.IsNullOrWhiteSpace(libro.FechaPublicacion) &&
                   libro.Autor != 0;
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _libroRepository.Delete(id);
                return Ok("Libro borrado!");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var libro = _libroRepository.GetById(id);
                if (libro != null)
                {
                    return Ok(libro);
                }
                else
                {
                    return StatusCode(404, "Libro no encontrado!");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro libro) 
        {
            try
            {
                if (id != 0 && id == libro.IdLibro && IsValid(libro))
                {
                    _libroRepository.Update(libro);
                    return Ok("Libro modificado!");
                }
                else
                {
                    return NotFound("No se encontró ese libro!");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno!");
            }

        }
    }
}
