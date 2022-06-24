using Flunt.Notifications;
using Flunt.Validations;

public static class CobrancaItemValidation
{
    public const int QUANTIDADE_PRECISION = 10;
    public const int QUANTIDADE_SCALE = 3;
    public const int PRECO_UNITARIO_PRECISION = 9;
    public const int PRECO_UNITARIO_SCALE = 2;

    public static Contract<Notification> Validacao(int? produtoId, int? servicoId, decimal quantidade) =>
        new Contract<Notification>()
            .IsFalse(produtoId.HasValue == servicoId.HasValue, string.Empty, "Deve ter apenas um produto ou um serviço")
            .IsLowerOrEqualsThan(quantidade, Extensions.MaximumNumberPossible(QUANTIDADE_PRECISION, QUANTIDADE_SCALE), "Quantidade");
}