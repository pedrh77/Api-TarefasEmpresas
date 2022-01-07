using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBackend.DTO
{
    public class EmpresasDTO
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
    }
}
