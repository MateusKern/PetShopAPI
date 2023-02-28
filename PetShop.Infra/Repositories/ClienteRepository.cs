using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Results;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    private readonly IMapper _mapper;

    public ClienteRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext)
    {
        _mapper = mapper;
    }

    public async Task<bool> ExistsCliente(int id) =>
        await _databaseContext.Set<Cliente>().AnyAsync(c => c.Id == id);

    public async Task<List<ClienteResult>> ObterTodosComPets() =>
        _mapper.Map<List<ClienteResult>>(await _databaseContext.Set<Cliente>().Include(c => c.Pets).ToListAsync());
}