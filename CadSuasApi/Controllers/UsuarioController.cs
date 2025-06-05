using CadSuasApi.Context;
using CadSuasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadSuasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // futuramente, essa funcionalidade será usada APENAS por pessoas que gerenciam o sistema como um todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            try
            {
                var users = await _context.Usuario.AsNoTracking().ToListAsync();
                if (!users.Any())
                {
                    return NotFound("Não existem usuários");
                }
                return users;
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro desonhecido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Usuario usuario)
        {

            try
            {
                if (usuario == null)
                {
                    return BadRequest("Dados inválidos");
                }

                if (await _context.Usuario.AnyAsync(u => u.Email == usuario.Email))
                {
                    return Conflict("Email já existe");
                }

                usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);

                usuario.DataCriacao = DateTime.UtcNow;
                usuario.Ativo = true;
                usuario.Role = "Comum";

                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = usuario.Id },
            new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Role,
                usuario.DataCriacao
            });

            }

            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
