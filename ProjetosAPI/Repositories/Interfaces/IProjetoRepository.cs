namespace ProjetosAPI.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        List<Projeto> Get();

        Projeto GetById(int id);

        List<Projeto> GetByUsuario (int usuarioId);

        void Add(Projeto projeto);

        void Update(Projeto projeto);

        void Delete(int id);
    }
}
