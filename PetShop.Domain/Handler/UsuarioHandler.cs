public class UsuarioHandler : IHandler<LoginCommand>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;

    public UsuarioHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<ResultComand> HandlerAsync(LoginCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        Usuario usuario = await _usuarioRepository.GetByLoginSenhaAsync(command.Login, command.Senha);

        if (usuario is null)
            result.AddNotification(string.Empty, "Login ou senha estão errados");

        if (usuario is not null && !usuario.Verificado)
            result.AddNotification(string.Empty, "Usuário não ativo no sistema");

        if (!result.IsValid)
            return result;

        result.PreencherRetorno(_tokenService.GetToken(usuario));

        return result;
    }
}