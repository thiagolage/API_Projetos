using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        public int IdTarefa { get; set; } //Id da Tarefa que o Comentário pertence

        public int IdUsuario { get; set; } //Usuário que criou o Comentário

        public DateTimeOffset DataCriacao { get; set; }

        public string? Texto { get; set; }
    }
}
