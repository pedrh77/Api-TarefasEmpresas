using DOMAIN.TarefasEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace INFRA.TarefasEmpresas.Context
{
    public class TarefasEmpresasContext : DbContext
    {
        public TarefasEmpresasContext(DbContextOptions<TarefasEmpresasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

    }
}
