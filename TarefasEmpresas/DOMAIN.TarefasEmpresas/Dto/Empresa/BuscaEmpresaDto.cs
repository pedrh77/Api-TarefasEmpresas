using System;

namespace DOMAIN.TarefasEmpresas.Dto.Empresa
{
    public class BuscaEmpresaDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
