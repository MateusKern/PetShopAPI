using Microsoft.AspNetCore.Mvc;

public class ClienteController : BaseController
{
    private readonly ClienteHandler _clienteHandler;
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(ClienteHandler clienteHandler, IClienteRepository clienteRepository)
    {
        _clienteHandler = clienteHandler;
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PegarClientes() =>
        ReturnActionResult(new ResultComand(await _clienteRepository.ObterTodos()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PegarClientePorId(int id) =>
        ReturnActionResult(new ResultComand(await _clienteRepository.ObterPorId(id)));

    [HttpPost]
    public async Task<IActionResult> NovoCliente([FromBody] NewClienteCommand command) =>
        ReturnActionResult(await _clienteHandler.HandlerAsync(command));

}