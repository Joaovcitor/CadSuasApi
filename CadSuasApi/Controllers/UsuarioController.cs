using CadSuasApi.Context;
using CadSuasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Dados inválidos");
            }
            
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = usuario.Id }, usuario);
        }
    }
}
