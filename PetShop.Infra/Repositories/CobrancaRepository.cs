using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Results;

public class CobrancaRepository : BaseRepository<Cobranca>, ICobrancaRepository
{
    private readonly IMapper _mapper;

    public CobrancaRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext)
    {
        _mapper = mapper;
    }

    public async Task<List<CobrancaResult>> ObterTodasComItens() =>
        _mapper.Map<List<CobrancaResult>>(await _databaseContext.Set<Cobranca>().Include(c => c.Cliente).Include(c => c.Colaborador)
                                                                                .Include(c => c.Itens).ThenInclude(i => i.Produto)
                                                                                .Include(c => c.Itens).ThenInclude(i => i.Servico).ToListAsync());
}