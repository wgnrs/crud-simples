using Microsoft.AspNetCore.Mvc;
using usuario.Models;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario {Id = 1, Nome = "Wagner"}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(usuarios);
        }
    }
}