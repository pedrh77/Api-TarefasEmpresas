using AutoMapper;
using DOMAIN.TarefasEmpresas.Dto.Empresa;
using DOMAIN.TarefasEmpresas.Interfaces;
using DOMAIN.TarefasEmpresas.Models;
using FluentResults;
using INFRA.TarefasEmpresas.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SERVICES.TarefasEmpresas.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly TarefasEmpresasContext _context;
        private readonly IMapper _mapper;

        public EmpresaService(TarefasEmpresasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BuscaEmpresaDto> BuscaEmpresas(string? cpf)
        {
            var empresas = new List<Empresa>();

            if (String.IsNullOrEmpty(cpf)) empresas = _context.Empresas.Where(i => i.IsDeleted != false).ToList();
            else empresas.Add(BuscaEmpresaPorcpf(cpf));
            if (empresas.Count == 0) throw new Exception("Empresas não existentes");
            var teste = _mapper.Map<List<BuscaEmpresaDto>>(empresas);
            return teste;

        }

        public Result CadastraEmpresa(CadastraEmpresaDto cadastraEmpresaDto)
        {
            if (cadastraEmpresaDto.Password != cadastraEmpresaDto.ConfirmPassword)
            {
                throw new Exception("Senhas não Coencidem");
            }
            var empresa = _context.Empresas.Where(i => i.Cpf.Equals(cadastraEmpresaDto.Cpf)).FirstOrDefault();

            if (empresa != null) throw new Exception("Cpf já cadastrado");

            var teste = _mapper.Map<Empresa>(cadastraEmpresaDto);
            _context.Empresas.Add(teste);
            _context.SaveChanges();
            return Result.Ok().WithSuccess(teste.Id.ToString());
        }


        public Result AtualizaEmpresa(string cpf, AtualizaEmpresaDto dto)
        {
            var empresa = BuscaEmpresaPorcpf(cpf);
            if (empresa == null) throw new Exception("Empresa não existente");
            empresa.Nome = (String.IsNullOrEmpty(dto.Nome) ? empresa.Nome : dto.Nome);
            empresa.Email = (String.IsNullOrEmpty(dto.Email) ? empresa.Email : dto.Email);
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return Result.Ok();

        }

        private Empresa BuscaEmpresaPorcpf(string? cpf)
        {
            var empresa = _context.Empresas.Where(i => i.IsDeleted != false && i.Cpf.Equals(cpf)).FirstOrDefault();
            if (empresa == null) throw new Exception("Empresas não existentes");
            return empresa;
        }

        public Result DeletarEmpresa(string cpf)
        {
            var empresa = BuscaEmpresaPorcpf(cpf);
            if (empresa == null) throw new Exception("Empresa não existente");
            empresa.IsDeleted = true;
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
