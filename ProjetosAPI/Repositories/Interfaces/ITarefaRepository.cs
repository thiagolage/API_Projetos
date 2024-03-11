namespace ProjetosAPI.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        List<Tarefa> Get();

        Tarefa GetById(int id);

        List<Tarefa> GetByProjeto(int projetoId);

        void Add(Tarefa tarefa);

        string Update(Tarefa tarefa);

        void Delete(int id);
    }
}
