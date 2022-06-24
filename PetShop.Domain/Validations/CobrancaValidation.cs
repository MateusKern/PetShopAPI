using Flunt.Notifications;
using Flunt.Validations;

public static class CobrancaValidation
{
    public const int DESCONTO_PRECISION = 6;
    public const int DESCONTO_SCALE = 2;

    public static Contract<Notification> Validacao(decimal desconto, int? clienteId, int colaboradorId)
    {
        var contract = new Contract<Notification>()
            .IsLowerOrEqualsThan(desconto, Extensions.MaximumNumberPossible(DESCONTO_PRECISION, DESCONTO_SCALE), "Desconto")
            .IsGreaterOrEqualsThan(desconto, 0, "Desconto")
            .IsGreaterThan(colaboradorId, 0, "ColaboradorId");

        if (clienteId.HasValue)
            contract.IsGreaterThan(clienteId.Value, 0, "ClienteId");

        return contract;
    }
}