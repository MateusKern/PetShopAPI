public class CobrancaItemCommand : Command
{
    public int? ProdutoId { get; private set; }
    public int? ServicoId { get; private set; }
    public decimal Quantidade { get; private set; }

    public override void Validate() =>
        AddNotifications(
            CobrancaItemValidation.Validacao(ProdutoId, ServicoId, Quantidade)
        );
}