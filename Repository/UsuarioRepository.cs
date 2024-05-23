using Microsoft.EntityFrameworkCore;
using usuario.Data;
using usuario.Models;

namespace usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public void AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public Task<Usuario> GetUsuariosById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}