public class Usuario
{
    private readonly List<ETipoAcesso> _acessos;

    private Usuario(int id, string login, string senha, bool verificado)
    {
        Id = id;
        Login = login;
        Senha = senha;
        Verificado = verificado;
    }

    public Usuario(string login, List<ETipoAcesso> acessos)
    {
        Login = login;
        _acessos = acessos;
        Senha = string.Empty;
        Verificado = false;
    }

    public int Id { get; private set; }
    public string Login { get; private set; }
    public string Senha { get; private set; }
    public bool Verificado { get; private set; }
    public IReadOnlyCollection<ETipoAcesso> Acessos { get => _acessos; }

    public void VerificarUsuario(string senha)
    {
        Senha = senha;
        Verificado = true;
    }
}