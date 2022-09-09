using Microsoft.AspNetCore.Mvc;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /* [HttpGet("GetItem")] */
        /* public async Task<ActionResult<Libro>> Get(int id) */
        /* { */
        /*     return await _context.Libros */
        /*         .Include(x => x.Author) */
        /*         .FirstOrDefaultAsync(x => x.Id == id); */
        /* } */

        /* [HttpPost("Create")] */
        /* public async Task<ActionResult> Post(Libro libro) */
        /* { */
        /*     var isThereAuthor = await _context.Autores.AnyAsync(x => x.Id == libro.AuthorId); */

        /*     if (!isThereAuthor) */
        /*     { */
        /*         return BadRequest($"No existe el autor de Id: {libro.AuthorId}"); */
        /*     } */

        /*     _context.Add(libro); */
        /*     await _context.SaveChangesAsync(); */
        /*     return Ok(); */
        /* } */
    }
}
