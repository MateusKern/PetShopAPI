using Flunt.Notifications;
using Flunt.Validations;

public static class PetValidation
{
    public const int NOME_MAXLENGTH = 20;
    public const int RACA_MAXLENGTH = 20;
    public const int COR_MAXLENGTH = 20;
    public const int PORTE_MAXLENGTH = 20;

    public static Contract<Notification> Validacao(string nome, string raca, string cor, string porte) =>
        new Contract<Notification>()
            .IsLowerOrEqualsThan(nome, NOME_MAXLENGTH, "Nome")
            .IsLowerOrEqualsThan(raca, RACA_MAXLENGTH, "Raca")
            .IsLowerOrEqualsThan(cor, COR_MAXLENGTH, "Cor")
            .IsLowerOrEqualsThan(porte, PORTE_MAXLENGTH, "Porte");
}