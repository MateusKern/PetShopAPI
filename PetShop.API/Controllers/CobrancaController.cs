using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/cobrancas")]
[ApiController]
[Authorize]
public class CobrancaController : BaseController
{
    private readonly CobrancaHandler _cobrancaHandler;
    private readonly ICobrancaRepository _cobrancaRepository;

    public CobrancaController(CobrancaHandler cobrancaHandler, ICobrancaRepository cobrancaRepository)
    {
        _cobrancaHandler = cobrancaHandler;
        _cobrancaRepository = cobrancaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PegarCobracas() =>
        ReturnActionResult(new ResultComand(await _cobrancaRepository.ObterTodos()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PegarCobrancaPorId(int id) =>
        ReturnActionResult(new ResultComand(await _cobrancaRepository.ObterPorId(id)));

    [HttpPost]
    public async Task<IActionResult> NovaCobranca([FromBody] NewCobrancaCommand command) =>
        ReturnActionResult(await _cobrancaHandler.HandlerAsync(command));

    [HttpPut]
    public async Task<IActionResult> PagamentoCobranca([FromBody] PaymentCobrancaCommand command) =>
        ReturnActionResult(await _cobrancaHandler.HandlerAsync(command));
}