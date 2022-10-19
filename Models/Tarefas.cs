using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DesafioBackend.Models
{
    public class Tarefas
    {
        public int IdTarefa { get; set; }
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string Local { get; set; }
        public String Data { get; set; }
        public bool StatusTarefa { get; set; }
    }
}
