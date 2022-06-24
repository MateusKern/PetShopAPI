using Microsoft.AspNetCore.Mvc;

public class CobrancaController : BaseController
{
    private readonly CobrancaHandler _cobrancaHandler;
    private readonly ICobrancaRepository _cobrancaRepository;

    public CobrancaController(CobrancaHandler cobrancaHandler, ICobrancaRepository cobrancaRepository)
    {
        this._cobrancaHandler = cobrancaHandler;
        this._cobrancaRepository = cobrancaRepository;
    }

    [HttpPost]
    public async Task<IActionResult> NovaCobranca([FromBody] NewCobrancaCommand command) =>
        ReturnActionResult(await _cobrancaHandler.HandlerAsync(command));

    [HttpPost]
    public async Task<IActionResult> PagamentoCobranca([FromBody] PaymentCobrancaCommand command) =>
        ReturnActionResult(await _cobrancaHandler.HandlerAsync(command));
}