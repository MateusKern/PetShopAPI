using Flunt.Notifications;
using Flunt.Validations;

public static class ClienteValidation
{
    public const int NOME_MAXLENGTH = 50;
    public const int TELEFONE_MAXLENGTH = 11;
    public const int EMAIL_MAXLENGTH = 50;
    public const int CPF_LENGTH = 11;

    public static Contract<Notification> Validacao(string nome, string telefone, string email, string cpf) =>
        new Contract<Notification>()
            .IsLowerOrEqualsThan(nome, NOME_MAXLENGTH, "Nome")
            .IsLowerOrEqualsThan(telefone, TELEFONE_MAXLENGTH, "Telefone")
            .IsLowerOrEqualsThan(email, EMAIL_MAXLENGTH, "Email")
            .IsEmailOrEmpty(email, "Email")
            .AreEquals(cpf, CPF_LENGTH, "Cpf");

}