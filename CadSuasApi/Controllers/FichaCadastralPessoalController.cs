using CadSuasApi.Context;
using CadSuasApi.Filters;
using CadSuasApi.Models;
using CadSuasApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadSuasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaCadastralPessoalController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public FichaCadastralPessoalController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FichaCadastralPessoal>> GetAsync()
        {
            var fichas = _uof.FichaCadastralRepository.GetAll();
            if (!fichas.Any())
            {
                return NotFound("Não existem fichas pessoais");
            }
            return Ok(fichas);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterFicha")]
        public ActionResult<FichaCadastralPessoal> GetByIdAsyn(int id)
        {
            var ficha = _uof.FichaCadastralRepository.Get(f => f.Id == id);
            if (ficha is null)
            {
                return NotFound("Ficha cadastral pessoal não encontrada");
            }
            return ficha;
        }

        [HttpPost]
        public ActionResult PostAsync(FichaCadastralPessoal fichaCadastral)
        {
            if (fichaCadastral is null)
            {
                return BadRequest();
            }
            _uof.FichaCadastralRepository.Create(fichaCadastral);
            _uof.Commit();
            return CreatedAtRoute("ObterFicha", new { id = fichaCadastral.Id }, fichaCadastral);
        }

        // esse metodo put vai ser realmente necessário?

        [HttpPut("{id:int}")]
        public ActionResult<FichaCadastralPessoal> Put(int id, FichaCadastralPessoal fichaCadastral)
        {

            if (id != fichaCadastral.Id)
            {
                return BadRequest($"o ID {id} não existe.");
            }

            var existingFicha = _uof.FichaCadastralRepository.Get(f => f.Id == id);
            if (existingFicha == null)
            {
                return NotFound();
            }

            _uof.FichaCadastralRepository.Update(existingFicha);
            _uof.Commit();
            return NoContent();
        }

        // é complicado, neste momento, definir esse metodo, pois, considerando que alguns funcionários podem acabar deletando sem querer uma ficha, poderia
        // causar problemas. Em breve, verei como será implementado, de forma segura, esse metodo

        // [HttpDelete("{id:int}")]
        // public async Task<ActionResult> DeleteAsync(int id)
        // {
        //     var ficha = await _context.FichaCadastralPessoal.FirstOrDefaultAsync(x => x.Id == id);
        //     if (ficha is null)
        //     {
        //         return NotFound("Ficha cadastral pessoal não encontrada");
        //     }
        //     _context.FichaCadastralPessoal.Remove(ficha);
        //     await _context.SaveChangesAsync();
        //     return Ok(ficha);
        // }
    }
}
