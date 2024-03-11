namespace ProjetosAPI.Repositories.Interfaces
{
    public interface IRelatorioRepository
    {
        RelatorioDesempenho DesempenhoPorUsuario(int idUsuarioSolicitante, int idUsuarioMedido, int qtdeDiasCalculo);
    }
}
