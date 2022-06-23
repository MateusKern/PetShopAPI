using Microsoft.EntityFrameworkCore;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext _databaseContext;

    public BaseRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task Adicionar(TEntity entity) =>
        await _databaseContext.Set<TEntity>().AddAsync(entity);

    public async Task AdicionarLista(IEnumerable<TEntity> entities) =>
        await _databaseContext.Set<TEntity>().AddRangeAsync(entities);

    public void Atualizar(TEntity entity) =>
        _databaseContext.Set<TEntity>().Update(entity);

    public void AtualizarLista(IEnumerable<TEntity> entities) =>
        _databaseContext.Set<TEntity>().UpdateRange(entities);

    public async Task<TEntity> ObterPorId(int id) =>
        await _databaseContext.Set<TEntity>().FindAsync(id);

    public async Task<List<TEntity>> ObterTodos() =>
        await _databaseContext.Set<TEntity>().ToListAsync();

    public void Remover(TEntity entity) =>
        _databaseContext.Remove(entity);

    public void RemoverLista(IEnumerable<TEntity> entities) =>
        _databaseContext.RemoveRange(entities);

    public async Task Commit() =>
        await _databaseContext.SaveChangesAsync();

    public void Dispose() =>
        _databaseContext.Dispose();
}