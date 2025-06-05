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

        public FichaCadastralPessoalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FichaCadastralPessoal>>> GetAsync()
        {
            try
            {
                var fichas = await _context.FichaCadastralPessoal.AsNoTracking().ToListAsync();
                if (!fichas.Any())
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

        [HttpGet("{id:int:min(1)}", Name = "ObterFicha")]
        public async Task<ActionResult<FichaCadastralPessoal>> GetByIdAsyn(int id)
        {

            try
            {
                var ficha = await _context.FichaCadastralPessoal.FirstOrDefaultAsync(x => x.Id == id);
                if (ficha is null)
                {
                    return NotFound("Ficha cadastral pessoal não encontrada");
                }
                return ficha;

            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro desconhecido ao buscar o dado!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(FichaCadastralPessoal fichaCadastral)
        {
            try
            {
                if (fichaCadastral is null)
                {
                    return BadRequest();
                }
                _context.FichaCadastralPessoal.Add(fichaCadastral);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetByIdAsyn), new { id = fichaCadastral.Id }, fichaCadastral);

            }

            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados!");
            }

            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao enviar os dados!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FichaCadastralPessoal>> Put(int id, FichaCadastralPessoal fichaCadastral)
        {

            try
            {
                if (id != fichaCadastral.Id)
                {
                    return BadRequest($"o ID {id} não existe.");
                }

                var existingFicha = await _context.FichaCadastralPessoal.FindAsync(id);
                if (existingFicha == null)
                {
                    return NotFound();
                }

                _context.Entry(existingFicha).CurrentValues.SetValues(fichaCadastral);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar os dados!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro desconhecido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var ficha = await _context.FichaCadastralPessoal.FirstOrDefaultAsync(x => x.Id == id);
                if (ficha is null)
                {
                    return NotFound("Ficha cadastral pessoal não encontrada");
                }
                _context.FichaCadastralPessoal.Remove(ficha);
                await _context.SaveChangesAsync();
                return Ok(ficha);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao deletar o dado!");
            }
        }
    }
}
