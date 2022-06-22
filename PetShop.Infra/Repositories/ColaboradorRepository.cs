public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
{
    public ColaboradorRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}