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
        }
    }
}
