using Microsoft.AspNetCore.Mvc;
using usuario.Models;
using usuario.Repository;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any()
                    ? Ok(usuarios)
                    : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario adicionado com sucesso")
                    : BadRequest("Erro ao salvar o usuario");
        }
    }
}