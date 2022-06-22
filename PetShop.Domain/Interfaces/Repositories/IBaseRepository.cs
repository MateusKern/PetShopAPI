public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task Adicionar(TEntity entity);
    Task AdicionarLista(IEnumerable<TEntity> entities);
    Task<TEntity> ObterPorId(int id);
    void Atualizar(TEntity entity);
    void AtualizarLista(IEnumerable<TEntity> entities);
    void Remover(TEntity entity);
    void RemoverLista(IEnumerable<TEntity> entities);
    Task Commit();
}