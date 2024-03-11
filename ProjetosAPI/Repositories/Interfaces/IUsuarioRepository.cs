namespace ProjetosAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();

        Usuario GetById(int id);

        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(int id);
    }
}
