public interface IClienteRepository : IBaseRepository<Cliente>
{
    Task<bool> ExistsCliente(int id);
    Task<List<Cliente>> ObterTodosComPets();
}