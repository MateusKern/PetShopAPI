using PetShop.Domain.Results;

public interface IClienteRepository : IBaseRepository<Cliente>
{
    Task<bool> ExistsCliente(int id);
    Task<List<ClienteResult>> ObterTodosComPets();
}