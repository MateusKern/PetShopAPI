using Microsoft.EntityFrameworkCore;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<bool> ExistsCliente(int id) =>
        await _databaseContext.Set<Cliente>().AnyAsync(c => c.Id == id);
}