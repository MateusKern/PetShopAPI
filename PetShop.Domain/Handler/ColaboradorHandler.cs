public class ColaboradorHandler : IHandler<NewColaboradorCommand>, IHandler<EditColaboradorCommand>, IHandler<DeleteCommand>
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public ColaboradorHandler(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<ResultComand> HandlerAsync(NewColaboradorCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var colaborador = new Colaborador(command.Nome, command.DataNascimento, command.Email, command.Acessos);
        result.AddNotifications(colaborador);

        if (result.IsValid)
        {
            await _colaboradorRepository.Adicionar(colaborador);
            await _colaboradorRepository.Commit();
        }

        return result;
    }

    public async Task<ResultComand> HandlerAsync(EditColaboradorCommand command)
    {
        ResultComand result = new();

        command.Validate();
        if (!command.IsValid)
        {
            result.AddNotifications(command);
            return result;
        }

        var colaborador = await _colaboradorRepository.ObterPorId(command.Id);

        if (colaborador is null)
        {
            result.AddNotification("Id", "Colaborador não encontrado");
            return result;
        }

        colaborador.EditarColaborador(command.Nome, command.DataNascimento);
        result.AddNotifications(colaborador);

        if (result.IsValid)
        {
            _colaboradorRepository.Atualizar(colaborador);
            await _colaboradorRepository.Commit();
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

        var colaborador = await _colaboradorRepository.ObterPorId(command.Id);

        if (colaborador is null)
        {
            result.AddNotification("Id", "Colaborador não encontrado");
            return result;
        }

        if (result.IsValid)
        {
            _colaboradorRepository.Remover(colaborador);
            await _colaboradorRepository.Commit();
        }

        return result;
    }
}