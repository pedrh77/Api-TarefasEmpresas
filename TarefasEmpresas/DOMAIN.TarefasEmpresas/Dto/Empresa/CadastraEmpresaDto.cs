using System.ComponentModel.DataAnnotations;

namespace DOMAIN.TarefasEmpresas.Dto.Empresa
{
    public class CadastraEmpresaDto
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(25, ErrorMessage = "Must be between 5 and 25 characters", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cpf is required")]
        [StringLength(11, ErrorMessage = "Must be a cpf characters", MinimumLength = 11)]
        public string Cpf { get; set; }
    }
}
