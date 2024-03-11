namespace ProjetosAPI.Repositories.Interfaces
{
    public interface ILogComentarioRepository
    {
        List<LogComentario> GetByComentario(int comentarioId);
    }
}
