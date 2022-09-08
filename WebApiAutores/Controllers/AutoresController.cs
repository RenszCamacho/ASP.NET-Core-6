using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;
using WebApiAutores.Filtros;
using WebApiAutores.Servicios;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IServicio _servicio;
        private readonly ServicioTransient _servicioTransient;
        private readonly ServicioScoped _servicioScoped;
        private readonly ServicioSingleton _servicioSingleton;
        private readonly ILogger<AutoresController> _logger;

        public AutoresController(
            ApplicationDbContext context,
            IServicio servicio,
            ServicioTransient servicioTransient,
            ServicioScoped servicioScoped,
            ServicioSingleton servicioSingleton,
            ILogger<AutoresController> logger
            )
        {
            _context = context;
            _servicio = servicio;
            _servicioTransient = servicioTransient;
            _servicioScoped = servicioScoped;
            _servicioSingleton = servicioSingleton;
            _logger = logger;
        }

        [HttpGet("GUID")]
        /* [ResponseCache(Duration = 10)] */
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult ObetenerGuids()
        {
            return Ok(new
            {
                AutoresController_Transient = _servicioTransient.Guid,
                ServicioA_Transient = _servicio.ObternerTransient(),

                AutoresController_Scoped = _servicioScoped.Guid,
                ServicioA_Scoped = _servicio.ObternerScoped(),

                AutoresController_Singleton = _servicioSingleton.Guid,
                ServicioA_Singleton = _servicio.ObternerSingleton(),
            });
        }

        [HttpGet("GetAll")]
        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            _logger.LogInformation("Estamos obteniendo los autores");
            _logger.LogWarning("Este es un mensaje de Aviso!");
            return await _context.Autores
                .Include(x => x.Libros)
                .ToListAsync();
        }

        [HttpGet("Primero")]
        public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int miValor, [FromQuery] string nombre)
        {
            return await _context.Autores.FirstOrDefaultAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Autor>> Get([FromRoute] string name)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Name.Contains(name));

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            var alreadyAuthorExist = await _context.Autores.AnyAsync(x => x.Name == autor.Name);
            if (alreadyAuthorExist)
            {
                return BadRequest("Ya existe el autor con el nombre" + " " + autor.Name);
            }
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            var isThereAuthor = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!isThereAuthor)
            {
                return NotFound();
            }

            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var isThereAuthor = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!isThereAuthor)
            {
                return NotFound();
            }

            _context.Remove(new Autor() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
