namespace ProjetosAPI.Repositories.Interfaces
{
    public interface ILogTarefaRepository
    {
        List<LogTarefa> GetByTarefa(int tarefaId);

        void Add(LogTarefa log);
    }
}
