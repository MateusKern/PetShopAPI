using AutoMapper;
using PetShop.Domain.Results;

namespace PetShop.Infra.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cliente, ClienteResult>()
                .ForMember(c => c.Cpf, r => r.MapFrom(m => m.Cpf.ReturnFormattedCpf()))
                .ForMember(c => c.Telefone, r => r.MapFrom(m => m.Telefone.ReturnFormattedPhone()));

            CreateMap<Pet, PetResult>().ForMember(p => p.Tipo, r => r.MapFrom(m => m.Tipo.ToString()));

            CreateMap<Cobranca, CobrancaResult>()
                .ForMember(c => c.Cliente, r => r.MapFrom(m => m.Cliente.Nome))
                .ForMember(c => c.Colaborador, r => r.MapFrom(m => m.Colaborador.Nome));

            CreateMap<CobrancaItem, CobrancaItemResult>()
                .ForMember(c => c.Produto, r => r.MapFrom(m => m.Produto.Nome))
                .ForMember(c => c.Servico, r => r.MapFrom(m => m.Servico.Nome));
        }
    }
}
