using CadSuasApi.Context;
using CadSuasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadSuasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaCadastralPessoalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FichaCadastralPessoalController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FichaCadastralPessoal>> Get()
        {
            try
            {
                var fichas = _context.FichaCadastralPessoal.AsNoTracking().ToList();
                if (fichas is null)
                {
                  return NotFound("Não a fichas pessoais");
                }
                return fichas;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação!");
            }
        }
    
        [HttpGet("{id:int:min(1}", Name = "ObterFicha")]
        public ActionResult<FichaCadastralPessoal> Get(int id)
        {
            var ficha = _context.FichaCadastralPessoal.FirstOrDefault(x => x.Id == id);
            if (ficha is null)
            {
                return NotFound("Ficha cadastral pessoal não encontrada");
            }
            return ficha;
        }

        [HttpPost]
        public ActionResult Post(FichaCadastralPessoal fichaCadastral)
        {
            if (fichaCadastral is null)
            {
                return BadRequest();
            }
            _context.FichaCadastralPessoal.Add(fichaCadastral);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterFicha", new {id = fichaCadastral.Id}, fichaCadastral);
        }

        [HttpPut("{id:int}")]
        public ActionResult<FichaCadastralPessoal> Put(int id, FichaCadastralPessoal fichaCadastral)
        {
            if (id != fichaCadastral.Id)
            {
                return BadRequest($"ID:{id}, OBJ: {fichaCadastral.Id}");
            }
            
            _context.Entry(fichaCadastral).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("id:int")]
        public ActionResult Delete(int id)
        {
            var ficha = _context.FichaCadastralPessoal.FirstOrDefault(x => x.Id == id);
            if (ficha is null)
            {
                return NotFound("Ficha cadastral pessoal não encontrada");
            }
            _context.FichaCadastralPessoal.Remove(ficha);
            _context.SaveChanges();
            return Ok(ficha);
        }
        
    }
}
