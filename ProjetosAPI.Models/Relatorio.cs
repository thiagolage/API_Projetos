using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Relatorio
    {
        public int idUsuarioSolicitante { get; set; }
    }

    public class RelatorioDesempenho
    {
        public int idUsuarioSolicitante { get; set; }

        public int idUsuarioMedido { get; set; }

        public int QtdeDiasCalculo { get; set; }

        public int QtdeTarefasAtribuidas { get; set; }

        public int QtdeTarefasConcluida { get; set; }

        public int QtdeTarefasEmAndamento { get; set; }

        public int QtdeTarefasPendente { get; set; }

        public double percentualTarefasConcluida { get; set; }

        public double percentualTarefasEmAndamento { get; set; }

        public double percentualTarefasPendente { get; set; }
    }
}
