using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBackend.DTO
{
    public class TarefasDTO
    {
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public Boolean Statustarefa { get; set; }
    }
}
