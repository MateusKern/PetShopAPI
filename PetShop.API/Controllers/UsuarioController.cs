using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UsuarioController : ControllerBase
{
    //[HttpPost("Login")]
    //public async Task<IActionResult> Login([FromBody] LoginCommand command)
    //{
    //    Ok("Logado");
    //}
}