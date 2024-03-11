using ProjetosAPI.Database;
using ProjetosAPI.Models;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class LogTarefaRepository : ILogTarefaRepository
    {
        private readonly ProjetosAPIContext _db;

        public LogTarefaRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public List<LogTarefa> GetByTarefa(int tarefaId)
        {
            return _db.LogTarefas.Where(t => t.IdTarefa == tarefaId).ToList();
        }

        public void Add(LogTarefa log)
        {
            _db.LogTarefas.Add(log);
            _db.SaveChanges();
        }
    }
}
