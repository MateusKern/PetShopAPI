public class ClienteHandler : IHandler<NewClienteCommand>
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
}