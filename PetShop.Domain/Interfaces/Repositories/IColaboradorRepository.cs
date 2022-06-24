public interface IColaboradorRepository : IBaseRepository<Colaborador>
{
    Task<bool> ExistsColaborador(int id);
}