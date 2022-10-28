using AutoMapper;
using DOMAIN.TarefasEmpresas.Dto.Empresa;
using DOMAIN.TarefasEmpresas.Models;
using System;

namespace DOMAIN.TarefasEmpresas.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CadastraEmpresaDto, Empresa>()
               .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(d => d.Cpf, opt => opt.MapFrom(src => src.Cpf))
               .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(d => d.IsDeleted, opt => opt.MapFrom(src => false))
               .ForMember(d => d.Nome, opt => opt.MapFrom(src => src.Nome))
               .ForMember(d => d.LastUpdatedAt, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<Empresa, BuscaEmpresaDto>()
                .ForMember(d => d.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

        }
    }
}
