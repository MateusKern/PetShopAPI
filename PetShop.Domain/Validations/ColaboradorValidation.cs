using Flunt.Notifications;
using Flunt.Validations;

public static class ColaboradorValidation
{
    public const int NOME_MAXLENGTH = 50;
    public const int EMAIL_MAXLENGTH = 50;

    public static Contract<Notification> Validacao(string nome, DateOnly? dataNascimento)
    {
        var contrato = new Contract<Notification>()
            .IsLowerOrEqualsThan(nome, NOME_MAXLENGTH, "Nome");

        if (dataNascimento is not null)
            contrato.IsLowerThan(new DateTime(dataNascimento.Value.Year, dataNascimento.Value.Month, dataNascimento.Value.Day), DateTime.Now, "DataNascimento");

        return contrato;
    }

    public static Contract<Notification> Validacao(string nome, DateOnly? dataNascimento, string email, List<ETipoAcesso> acessos)
    {
        var contrato = Validacao(nome, dataNascimento);

        contrato
            .IsLowerOrEqualsThan(email, EMAIL_MAXLENGTH, "Email")
            .IsEmailOrEmpty(email, "Email");

        if (acessos is not null)
        {
            if (acessos.Contains(ETipoAcesso.Administrador))
                contrato.AddNotification("Acessos", "Colaborador não pode ter acesso de Administrador");

            if (acessos.Contains(ETipoAcesso.Cliente))
                contrato.AddNotification("Acessos", "Colaborador não pode ter acesso de Cliente");
        }

        return contrato;
    }
}