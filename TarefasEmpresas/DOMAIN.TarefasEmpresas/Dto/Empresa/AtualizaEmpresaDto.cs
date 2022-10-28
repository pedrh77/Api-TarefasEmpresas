using System.ComponentModel.DataAnnotations;

namespace DOMAIN.TarefasEmpresas.Dto.Empresa
{
    public class AtualizaEmpresaDto
    {
        [StringLength(25, ErrorMessage = "Must be between 5 and 25 characters", MinimumLength = 5)]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
    }
}
