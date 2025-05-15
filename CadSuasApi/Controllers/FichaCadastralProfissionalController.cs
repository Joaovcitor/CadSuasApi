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
        public ActionResult<IEnumerable<FichaCadastralProfissional>> GetFichasProfissionaisActionResult()
        {
            return _context.FichaCadastralProfissional.Include(f => f.FichaCadastralPessoal).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<FichaCadastralProfissional>> Get()
        {
            return _context.FichaCadastralProfissional.ToList();
        }

        [HttpGet("{id:int}",  Name = "Get")]
        public ActionResult<FichaCadastralProfissional> Get(int id)
        {
            try
            {
                var ficha = _context.FichaCadastralProfissional.FirstOrDefault(f => f.Id == id);
                if (ficha == null)
                {
                    return NotFound();
                }
                return Ok(ficha);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar a ficha de ID:{id}");
            }
        }

        [HttpPost]
        public ActionResult Post(FichaCadastralProfissional ficha)
        {
            try
            {
                if (ficha == null)
                {
                    return BadRequest();
                }
                _context.FichaCadastralProfissional.Add(ficha);
                _context.SaveChanges();
                return new CreatedAtRouteResult("Get", new { id = ficha.Id }, ficha);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Erro ao cadastrar ficha");
            }
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
