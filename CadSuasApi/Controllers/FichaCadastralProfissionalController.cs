using CadSuasApi.Context;
using CadSuasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadSuasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaCadastralProfissionalController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FichaCadastralProfissionalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("fichas")]
        public async Task<ActionResult<IEnumerable<FichaCadastralProfissional>>> GetFichasProfissionaisActionResultAsync()
        {
            return await _context.FichaCadastralProfissional.Include(f => f.FichaCadastralPessoal).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FichaCadastralProfissional>>> Get()
        {
            return _context.FichaCadastralProfissional.ToList();
        }

        [HttpGet("{id:int}", Name = "Get")]
        public ActionResult<FichaCadastralProfissional> Get(int id)
        {
            var ficha = _context.FichaCadastralProfissional.FirstOrDefault(f => f.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }
            return Ok(ficha);
        }

        [HttpPost]
        public ActionResult Post(FichaCadastralProfissional ficha)
        {
            if (ficha == null)
            {
                return BadRequest();
            }
            _context.FichaCadastralProfissional.Add(ficha);
            _context.SaveChanges();
            return new CreatedAtRouteResult("Get", new { id = ficha.Id }, ficha);
        }

        [HttpPut("{id:int}")]
        public ActionResult<FichaCadastralProfissional> Put(int id, FichaCadastralProfissional fichaCadastral)
        {
            if (id != fichaCadastral.Id)
            {
                return BadRequest($"ID:{id}, OBJ: {fichaCadastral.Id}");
            }

            _context.Entry(fichaCadastral).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var ficha = _context.FichaCadastralProfissional.FirstOrDefault(f => f.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }

            _context.FichaCadastralProfissional.Remove(ficha);
            _context.SaveChanges();
            return Ok(ficha);
        }

    }
}
