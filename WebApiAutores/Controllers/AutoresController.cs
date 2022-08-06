using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await _context.Autores.ToListAsync();
        }
    }
}
