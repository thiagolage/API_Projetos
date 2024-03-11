using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public DateTimeOffset DataCriacao { get; set; }

        public int IdUsuarioCriador { get; set; } //Usuário que criou o Projeto

        public int IdUsuarioAssignee { get; set; } //Atual responsável pelo projeto
    }
}
