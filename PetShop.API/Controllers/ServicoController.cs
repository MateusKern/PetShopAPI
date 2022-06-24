using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/servicos")]
[ApiController]
[Authorize]
public class ServicoController : BaseController
{
    private readonly ServicoHandler _servicoHandler;
    private readonly IServicoRepository _servicoRepository;

    public ServicoController(ServicoHandler servicoHandler, IServicoRepository servicoRepository)
    {
        _servicoHandler = servicoHandler;
        _servicoRepository = servicoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PegarServicos() =>
        ReturnActionResult(new ResultComand(await _servicoRepository.ObterTodos()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PegarServicoPorId(int id) =>
        ReturnActionResult(new ResultComand(await _servicoRepository.ObterPorId(id)));

    [HttpPost]
    public async Task<IActionResult> NovoServico([FromBody] NewServicoCommand command) =>
        ReturnActionResult(await _servicoHandler.HandlerAsync(command));

    [HttpPut]
    public async Task<IActionResult> EditarServico([FromBody] EditServicoCommand command) =>
        ReturnActionResult(await _servicoHandler.HandlerAsync(command));

    [HttpDelete]
    public async Task<IActionResult> DeletarServico([FromBody] DeleteCommand command) =>
        ReturnActionResult(await _servicoHandler.HandlerAsync(command));
}