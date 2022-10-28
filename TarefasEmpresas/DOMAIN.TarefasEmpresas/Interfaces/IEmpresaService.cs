using DOMAIN.TarefasEmpresas.Dto.Empresa;
using FluentResults;
using System.Collections.Generic;

namespace DOMAIN.TarefasEmpresas.Interfaces
{
    public interface IEmpresaService
    {
        public Result CadastraEmpresa(CadastraEmpresaDto cadastraEmpresaDto);
        public List<BuscaEmpresaDto> BuscaEmpresas(string? cpf);
        public Result AtualizaEmpresa(string cpf, AtualizaEmpresaDto dto);
        public Result DeletarEmpresa(string cpf);
    }
}
