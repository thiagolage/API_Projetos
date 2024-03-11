using ProjetosAPI.Database;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class LogComentarioRepository : ILogComentarioRepository
    {
        private readonly ProjetosAPIContext _db;

        public LogComentarioRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<LogComentario> GetByComentario(int comentarioId)
        {
            return _db.LogComentarios.Where(c => c.IdComentario == comentarioId).OrderByDescending(c => c.Id ).ToList();
        }
    }
}
