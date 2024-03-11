using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosAPI.Models
{
    public class LogTarefa
    {
        public int Id { get; set; }

        public int IdTarefa { get; set; }

        public DateTimeOffset DataAlteracao { get; set; }

        public string? CampoModificado { get; set; }

        public string? ValorAnterior { get; set; }

        public string? NovoValor { get; set; }

        public int IdUsuario { get; set; }
    }
}
