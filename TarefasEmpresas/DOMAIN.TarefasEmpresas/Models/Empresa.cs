namespace DOMAIN.TarefasEmpresas.Models
{
    public class Empresa : BaseEntity
    {
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
