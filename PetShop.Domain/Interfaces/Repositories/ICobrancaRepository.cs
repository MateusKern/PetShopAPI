using PetShop.Domain.Results;

public interface ICobrancaRepository : IBaseRepository<Cobranca>
{
    Task<List<CobrancaResult>> ObterTodasComItens();
}