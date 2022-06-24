using Microsoft.EntityFrameworkCore;

public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
{
    public ColaboradorRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<bool> ExistsColaborador(int id) =>
        await _databaseContext.Set<Colaborador>().AnyAsync(c => c.Id == id);
}