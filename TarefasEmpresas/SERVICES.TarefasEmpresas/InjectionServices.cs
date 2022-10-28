using DOMAIN.TarefasEmpresas.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SERVICES.TarefasEmpresas.Services;

namespace SERVICES.TarefasEmpresas
{
    public class InjectionServices
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IEmpresaService, EmpresaService>();
        }
    }
}
