using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTimeOffset DataCriacao { get; set; }

        public DateTimeOffset DataVencimento { get; set; }

        public DateTimeOffset? DataConclusao { get; set; }

        public int Status { get; set; }

        public int Prioridade { get; set; }

        public int IdUsuarioAssignee { get; set; } //Usuario responsável pela Tarefa

        public int IdProjeto { get; set; } //Projeto a que a Tarefa pertence
    }
}
