public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
{
    public ServicoRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}