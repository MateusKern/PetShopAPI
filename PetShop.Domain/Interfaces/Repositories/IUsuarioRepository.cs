public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> GetByLoginSenhaAsync(string login, string senha);
}