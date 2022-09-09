using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetItem")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(libroDB => libroDB.Id == id);

            return _mapper.Map<LibroDTO>(libro);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Post(LibroCreacionDTO libroCreacionDTO)
        {
            /* var isThereAuthor = await _context.Autores.AnyAsync(x => x.Id == libro.AuthorId); */

            /* if (!isThereAuthor) */
            /* { */
            /*     return BadRequest($"No existe el autor de Id: {libro.AuthorId}"); */
            /* } */

            var libro = _mapper.Map<Libro>(libroCreacionDTO);

            _context.Add(libro);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
