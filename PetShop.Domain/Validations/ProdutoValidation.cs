using Flunt.Notifications;
using Flunt.Validations;

public static class ProdutoValidation
{
    public const int NOME_MAXLENGTH = 30;
    public const int DESCRICAO_MAXLENGTH = 150;
    public const int PRECO_PRECISION = 7;
    public const int PRECO_SCALE = 2;

    public static Contract<Notification> Validacao(int id, string nome, string descricao, decimal preco) =>
        Validacao(nome, descricao, preco)
            .IsGreaterThan(id, 0, "Id");

    public static Contract<Notification> Validacao(string nome, string descricao, decimal preco) =>
        new Contract<Notification>()
            .IsLowerOrEqualsThan(nome, NOME_MAXLENGTH, "Nome")
            .IsNotNull(nome, "Nome")
            .IsLowerOrEqualsThan(descricao, DESCRICAO_MAXLENGTH, "Descricao")
            .IsNotNull(descricao, "Descricao")
            .IsLowerOrEqualsThan(preco, Extensions.MaximumNumberPossible(PRECO_PRECISION, PRECO_SCALE), "Preco")
            .IsGreaterThan(preco, 0, "Preco");
}