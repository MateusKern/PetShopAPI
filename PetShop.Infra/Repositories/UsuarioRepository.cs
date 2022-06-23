using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<Usuario> GetByLoginSenhaAsync(string login, string senha) =>
        await _databaseContext.Set<Usuario>().FirstOrDefaultAsync(u => u.Login == login && u.Senha == senha);
}