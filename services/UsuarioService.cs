using loja.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loja.services
{
    public class UsuarioService
    {
        private readonly List<UsuarioModel> _usuarios = new List<UsuarioModel>();
        private int _nextId = 1;

        public Task<List<UsuarioModel>> GetAllUsuariosAsync()
        {
            return Task.FromResult(_usuarios);
        }

        public Task<UsuarioModel> GetUsuarioByIdAsync(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(usuario);
        }

        public Task AddUsuarioAsync(UsuarioModel usuario)
        {
            usuario.Id = _nextId++;
            _usuarios.Add(usuario);
            return Task.CompletedTask;
        }

        public Task<UsuarioModel> GetUsuarioByEmailAsync(string email)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(usuario);
        }
    }
}
