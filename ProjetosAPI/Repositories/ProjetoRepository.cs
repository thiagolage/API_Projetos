using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Database;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProjetosAPIContext _db;

        public ProjetoRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<Projeto> Get()
        {
            return _db.Projetos.ToList();
        }

        public Projeto GetById(int id)
        {
            return _db.Projetos.Find(id)!;
        }

        public List<Projeto> GetByUsuario(int usuarioId)
        {
            return _db.Projetos.Where(p => p.IdUsuarioAssignee == usuarioId).ToList();
        }

        public void Add(Projeto projeto)
        {
            _db.Projetos.Add(projeto);
            _db.SaveChanges();
        }

        public void Update(Projeto projeto)
        {
            _db.Projetos.Update(projeto);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Projetos.Remove(GetById(id));
            _db.SaveChanges();
        }
    }
}
