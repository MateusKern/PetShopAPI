public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}