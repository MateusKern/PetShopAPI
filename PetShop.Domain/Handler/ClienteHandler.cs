public class ClienteHandler : IHandler<NewClienteCommand>, IHandler<EditClienteCommand>, IHandler<DeleteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ResultComand> HandlerAsync(NewClienteCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var cliente = new Cliente(command.Nome, command.Telefone, command.Email, command.Cpf, command.Pets.Select(p => p.ConvertPet()));
        result.AddNotifications(cliente);

        if (result.IsValid)
        {
            await _clienteRepository.Adicionar(cliente);
            await _clienteRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(EditClienteCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var cliente = await _clienteRepository.ObterPorId(command.Id);

        if (cliente is null)
        {
            result.AddNotification("Id", "Cliente não encontrado");
            return result;
        }

        cliente.EditarCliente(command.Nome, command.Telefone, command.Email, command.Cpf, command.Pets.Select(p => p.ConvertPet()));
        result.AddNotifications(cliente);

        if (result.IsValid)
        {
            _clienteRepository.Atualizar(cliente);
            await _clienteRepository.Commit();
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

        var cliente = await _clienteRepository.ObterPorId(command.Id);

        if (cliente is null)
        {
            result.AddNotification("Id", "Cliente não encontrado");
            return result;
        }

        if (result.IsValid)
        {
            _clienteRepository.Remover(cliente);
            await _clienteRepository.Commit();
        }

        return result;
    }
}