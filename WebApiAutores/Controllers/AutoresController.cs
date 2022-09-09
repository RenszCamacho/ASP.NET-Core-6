﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var autores = await _context.Autores
                /* .Include(x => x.Libros) */
                .ToListAsync();

            return _mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string name)
        {
            var autores = await _context.Autores.Where(autorDB => autorDB.Name.Contains(name)).ToListAsync();

            return _mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(autorDB => autorDB.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return _mapper.Map<AutorDTO>(autor);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDTO)
        {
            var alreadyAuthorExist = await _context.Autores.AnyAsync(x => x.Name == autorCreacionDTO.Name);
            if (alreadyAuthorExist)
            {
                return BadRequest("Ya existe el autor con el nombre" + " " + autorCreacionDTO.Name);
            }
            
            var autor = _mapper.Map<Autor>(autorCreacionDTO);

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
