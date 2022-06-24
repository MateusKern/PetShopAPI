public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}