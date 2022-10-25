using ExoApi.Contexts;
using ExoApi.Interfaces;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbExoAPIContext _context;

        public UsuarioRepository(dbExoAPIContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usurarioEncontrado = _context.Usuarios.Find(id);
            if (usurarioEncontrado != null)
            {
                usurarioEncontrado.Email = usuario.Email;
                usurarioEncontrado.Senha = usuario.Senha;
                usurarioEncontrado.Tipo = usuario.Tipo;

                _context.Usuarios.Update(usurarioEncontrado);
                _context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioEncontrado);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
