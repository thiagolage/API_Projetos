using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class LogComentario
    {
        public int Id { get; set; }

        public int IdComentario { get; set; }

        public DateTimeOffset DataAlteracao { get; set; }

        public string? ValorAnterior { get; set; }

        public string? NovoValor { get; set; }

        public int IdUsuario { get; set; }
    }
}
