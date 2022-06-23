using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/colaboradores")]
[ApiController]
[Authorize]
public class ColaboradorController : BaseController
{
    private readonly ColaboradorHandler _colaboradorHandler;
    private readonly IColaboradorRepository _colaboradorRepository;

    public ColaboradorController(ColaboradorHandler colaboradorHandler, IColaboradorRepository colaboradorRepository)
    {
        _colaboradorHandler = colaboradorHandler;
        _colaboradorRepository = colaboradorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PegarColaboradores() =>
        ReturnActionResult(new ResultComand(await _colaboradorRepository.ObterTodos()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PegarColaboradorePorId(int id) =>
        ReturnActionResult(new ResultComand(await _colaboradorRepository.ObterPorId(id)));

    [HttpPost]
    public async Task<IActionResult> NovoColaborador([FromBody] NewColaboradorCommand command) =>
        ReturnActionResult(await _colaboradorHandler.HandlerAsync(command));

    [HttpPut]
    public async Task<IActionResult> EditarColaborador([FromBody] EditColaboradorCommand command) =>
        ReturnActionResult(await _colaboradorHandler.HandlerAsync(command));

    [HttpDelete]
    public async Task<IActionResult> DeletarColaborador([FromBody] DeleteCommand command) =>
        ReturnActionResult(await _colaboradorHandler.HandlerAsync(command));
}