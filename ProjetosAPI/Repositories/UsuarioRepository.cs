using ProjetosAPI.Database;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjetosAPIContext _db;

        public UsuarioRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _db.Usuarios.Find(id)!;
        }

        public void Add(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario usuario = GetById(id);
            usuario.Ativo = false;
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }
    }
}
