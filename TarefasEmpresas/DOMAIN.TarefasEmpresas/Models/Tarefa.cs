using System;

namespace DOMAIN.TarefasEmpresas.Models
{
    public class Tarefa : BaseEntity
    {
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresas { get; set; }
        public string NomeEmpresa { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool StatusTarefa { get; set; }
    }
}
