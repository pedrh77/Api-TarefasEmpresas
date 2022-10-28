using DOMAIN.TarefasEmpresas.Dto.Empresa;
using DOMAIN.TarefasEmpresas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.TarefasEmpresas.Controllers
{
    [Route("api/[Controller]/")]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        [HttpGet("{cpf}")]
        [SwaggerOperation(OperationId = "BuscaEmpresaPorId",
                            Summary = "Busca Empresa por Id")]
        public IActionResult BuscaEmpresaPorId(string? cpf)
        {
            var result = _empresaService.BuscaEmpresas(cpf);
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "CadastraNovaEmpresa",
                             Summary = "Cadastro de Nova Empresa")]
        public IActionResult CadastraEmpresa(CadastraEmpresaDto dto)
        {
            var result = _empresaService.CadastraEmpresa(dto);
            if (result.IsFailed) { return BadRequest(result); }
            return Ok(result.Successes);
        }

        [HttpPut("/{cpf}")]
        [SwaggerOperation(OperationId = "AtualizaEmpresa",
                            Summary = "Atualiza Empresa por cpf")]
        public IActionResult AtualizaEmpresa(string? cpf, AtualizaEmpresaDto dto)
        {
            var result = _empresaService.AtualizaEmpresa(cpf, dto);
            return Ok(result);
        }

        [HttpDelete("/{cpf}")]
        [SwaggerOperation(OperationId = "DeletarEmpresa",
                           Summary = "Deletar Empresa por cpf")]
        public IActionResult DeletarEmpresa(string? cpf)
        {
            var result = _empresaService.DeletarEmpresa(cpf);
            return Ok(result);
        }
    }
}
