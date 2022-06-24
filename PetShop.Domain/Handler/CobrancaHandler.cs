public class CobrancaHandler : IHandler<NewCobrancaCommand>, IHandler<PaymentCobrancaCommand>
{
    private readonly ICobrancaRepository _cobrancaRepository;
    private readonly IColaboradorRepository _colaboradorRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IServicoRepository _servicoRepository;

    public CobrancaHandler(ICobrancaRepository cobrancaRepository, IColaboradorRepository colaboradorRepository, IClienteRepository clienteRepository,
                           IProdutoRepository produtoRepository, IServicoRepository servicoRepository)
    {
        _cobrancaRepository = cobrancaRepository;
        _colaboradorRepository = colaboradorRepository;
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
        _servicoRepository = servicoRepository;
    }

    public async Task<ResultComand> HandlerAsync(NewCobrancaCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        if (command.ClienteId.HasValue && !await _clienteRepository.ExistsCliente(command.ClienteId.Value))
            result.AddNotification("ClienteId", "Cliente não encontrado");

        if (!await _colaboradorRepository.ExistsColaborador(command.ColaboradorId))
            result.AddNotification("ColaboradorId", "Colaborador não encontrado");

        var cobranca = new Cobranca(command.EstaPaga,command.Desconto, command.ClienteId, command.ColaboradorId);

        if (command.Itens is not null)
        {
            Produto produto;
            Servico servico;
            for (int i = 0; i < command.Itens.Count; i++)
            {
                produto = null;
                servico = null;

                if (command.Itens[i].ProdutoId.HasValue)
                {
                    produto = await _produtoRepository.ObterPorId(command.Itens[i].ProdutoId.Value);

                    if (produto is not null)
                        cobranca.AddItem(new CobrancaItem(produto.Id, null, command.Itens[i].Quantidade, produto.Preco));
                    else
                        result.AddNotification($"Itens.{i}.ProdutoId", "Produto não encontrado");
                }

                if (command.Itens[i].ServicoId.HasValue)
                {
                    servico = await _servicoRepository.ObterPorId(command.Itens[i].ServicoId.Value);

                    if (servico is not null)
                        cobranca.AddItem(new CobrancaItem(null, servico.Id, command.Itens[i].Quantidade, servico.Preco));
                    else
                        result.AddNotification($"Itens.{i}.ServicoId", "Serviço não encontrado");
                }
            }
        }

        result.AddNotifications(cobranca);

        if (result.IsValid)
        {
            await _cobrancaRepository.Adicionar(cobranca);
            await _cobrancaRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(PaymentCobrancaCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var cobranca = await _cobrancaRepository.ObterPorId(command.Id);

        if (cobranca is null)
        {
            result.AddNotification("Id", "Cobrança não encontrada");
            return result;
        }

        cobranca.PagarCobranca();
        result.AddNotifications(cobranca);

        if (result.IsValid)
        {
            _cobrancaRepository.Atualizar(cobranca);
            await _cobrancaRepository.Commit();
        }

        return result;
    }
}