using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
[AllowAnonymous]
public class UsuarioController : BaseController
{
    private readonly UsuarioHandler _usuarioHandler;

    public UsuarioController(UsuarioHandler usuarioHandler)
    {
        _usuarioHandler = usuarioHandler;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command) =>
        ReturnActionResult(await _usuarioHandler.HandlerAsync(command));
}