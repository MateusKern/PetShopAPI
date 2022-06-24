using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/produtos")]
[ApiController]
[Authorize]
public class ProdutoController : BaseController
{
    private readonly ProdutoHandler _produtoHandler;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(ProdutoHandler produtoHandler, IProdutoRepository produtoRepository)
    {
        _produtoHandler = produtoHandler;
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> PegarProdutos() =>
        ReturnActionResult(new ResultComand(await _produtoRepository.ObterTodos()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> PegarProdutoPorId(int id) =>
        ReturnActionResult(new ResultComand(await _produtoRepository.ObterPorId(id)));

    [HttpPost]
    public async Task<IActionResult> NovoProduto([FromBody] NewProdutoCommand command) =>
        ReturnActionResult(await _produtoHandler.HandlerAsync(command));

    [HttpPut]
    public async Task<IActionResult> EditarProduto([FromBody] EditProdutoCommand command) =>
        ReturnActionResult(await _produtoHandler.HandlerAsync(command));

    [HttpDelete]
    public async Task<IActionResult> DeletarProduto([FromBody] DeleteCommand command) =>
        ReturnActionResult(await _produtoHandler.HandlerAsync(command));
}