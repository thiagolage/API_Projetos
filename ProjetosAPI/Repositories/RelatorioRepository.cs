using ProjetosAPI.Database;
using ProjetosAPI.Enums;
using ProjetosAPI.Repositories.Interfaces;

namespace ProjetosAPI.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ProjetosAPIContext _db;

        public RelatorioRepository(ProjetosAPIContext db)
        {
            _db = db;
        }

        public RelatorioDesempenho DesempenhoPorUsuario(int idUsuarioSolicitante, int idUsuarioMedido, int qtdeDiasCalculo)
        {
            Usuario usuario = _db.Usuarios.FirstOrDefault(u => u.Id == idUsuarioSolicitante)!;

            RelatorioDesempenho resposta = new RelatorioDesempenho();

            var listaTarefas = _db.Tarefas.Where(t => t.IdUsuarioAssignee == idUsuarioMedido
                && t.DataCriacao >= DateTimeOffset.Now.AddDays(-qtdeDiasCalculo))
                    .ToList();

            int qtdeTarefasPendente = 0;
            int qtdeTarefasAndamento = 0;
            int qtdeTarefasConcluida = 0;

            foreach (var tarefa in listaTarefas)
            {
                switch (tarefa.Status)
                {
                    case (int)Enumerators.StatusTarefa.Pendente: //Pendente
                        qtdeTarefasPendente++;
                        break;
                    case (int)Enumerators.StatusTarefa.Andamento: //Em andamento
                        qtdeTarefasAndamento++;
                        break;
                    case (int)Enumerators.StatusTarefa.Concluído: //Concluída
                        qtdeTarefasConcluida++;
                        break;
                }
            }

            resposta.idUsuarioSolicitante = idUsuarioSolicitante;
            resposta.idUsuarioMedido = idUsuarioMedido;
            resposta.QtdeDiasCalculo = qtdeDiasCalculo;
            resposta.QtdeTarefasAtribuidas = listaTarefas.Count();
            resposta.QtdeTarefasConcluida = qtdeTarefasConcluida;
            resposta.QtdeTarefasEmAndamento = qtdeTarefasAndamento;
            resposta.QtdeTarefasPendente = qtdeTarefasPendente;

            double percentualConcluida = Math.Round((100 * (double)qtdeTarefasConcluida) / (double)listaTarefas.Count(), 2);
            double percentualAndamento = Math.Round((100 * (double)qtdeTarefasAndamento) / (double)listaTarefas.Count(), 2);
            double percentualPendente = Math.Round((100 * (double)qtdeTarefasPendente) / (double)listaTarefas.Count(), 2);

            resposta.percentualTarefasConcluida = percentualConcluida;
            resposta.percentualTarefasEmAndamento = percentualAndamento;
            resposta.percentualTarefasPendente = percentualPendente;

            return resposta;
        }
    }
}
