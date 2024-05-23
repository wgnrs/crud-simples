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

        public async Task<Usuario> GetUsuariosById(int id)
        {
            return await _context.Usuarios.
                        Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
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