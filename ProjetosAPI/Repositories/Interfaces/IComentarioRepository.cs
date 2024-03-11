namespace ProjetosAPI.Repositories.Interfaces
{
    public interface IComentarioRepository
    {
        List<Comentario> Get();

        Comentario GetById(int id);

        List<Comentario> GetByTarefa(int idTarefa);

        bool Add(Comentario tarefa);

        bool Update(Comentario tarefa);

        void Delete(int id);
    }
}
