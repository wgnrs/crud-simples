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
                    : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarios = await _repository.GetUsuariosById(id);
            return usuarios != null
                    ? Ok(usuarios)
                    : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario adicionado com sucesso")
                    : BadRequest("Erro ao salvar o usuario");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usuarioBanco = await _repository.GetUsuariosById(id);
            if (usuarioBanco == null) return NotFound("Usuário não encontrado");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNascimento = usuario.DataNascimento == new DateTime()
            ? usuario.DataNascimento : usuarioBanco.DataNascimento;

            _repository.UpdateUsuario(usuarioBanco);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario atualizado com sucesso")
                    : BadRequest("Erro ao atualizar o usuario");
        }
    }
}