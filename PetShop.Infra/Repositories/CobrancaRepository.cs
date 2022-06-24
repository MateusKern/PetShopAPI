public class CobrancaRepository : BaseRepository<Cobranca>, ICobrancaRepository
{
    public CobrancaRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}