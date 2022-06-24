public class ServicoHandler : IHandler<NewServicoCommand>, IHandler<EditServicoCommand>, IHandler<DeleteCommand>
{
    private readonly IServicoRepository _servicoRepository;

    public ServicoHandler(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ResultComand> HandlerAsync(NewServicoCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var servico = new Servico(0, command.Nome, command.Descricao, command.Preco);
        result.AddNotifications(servico);

        if (result.IsValid)
        {
            await _servicoRepository.Adicionar(servico);
            await _servicoRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(EditServicoCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var servico = await _servicoRepository.ObterPorId(command.Id);

        if (servico is null)
        {
            result.AddNotification("Id", "Servico não encontrado");
            return result;
        }

        servico.EditarServico(command.Nome, command.Descricao, command.Preco);
        result.AddNotifications(servico);

        if (result.IsValid)
        {
            _servicoRepository.Atualizar(servico);
            await _servicoRepository.Commit();
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

        var servico = await _servicoRepository.ObterPorId(command.Id);

        if (servico is null)
        {
            result.AddNotification("Id", "Servico não encontrado");
            return result;
        }

        if (result.IsValid)
        {
            _servicoRepository.Remover(servico);
            await _servicoRepository.Commit();
        }

        return result;
    }
}