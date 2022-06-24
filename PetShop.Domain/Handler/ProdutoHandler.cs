public class ProdutoHandler : IHandler<NewProdutoCommand>, IHandler<EditProdutoCommand>, IHandler<DeleteCommand>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResultComand> HandlerAsync(NewProdutoCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var produto = new Produto(0, command.Nome, command.Descricao, command.Preco);
        result.AddNotifications(produto);

        if (result.IsValid)
        {
            await _produtoRepository.Adicionar(produto);
            await _produtoRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(EditProdutoCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var produto = await _produtoRepository.ObterPorId(command.Id);

        if (produto is null)
        {
            result.AddNotification("Id", "Produto não encontrado");
            return result;
        }

        produto.EditarProduto(command.Nome, command.Descricao, command.Preco);
        result.AddNotifications(produto);

        if (result.IsValid)
        {
            _produtoRepository.Atualizar(produto);
            await _produtoRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(DeleteCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var produto = await _produtoRepository.ObterPorId(command.Id);

        if (produto is null)
        {
            result.AddNotification("Id", "Produto não encontrado");
            return result;
        }

        if (result.IsValid)
        {
            _produtoRepository.Remover(produto);
            await _produtoRepository.Commit();
        }

        return result;
    }
}