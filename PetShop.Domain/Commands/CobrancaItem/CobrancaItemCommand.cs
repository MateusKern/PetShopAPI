public class CobrancaItemCommand : Command
{
    public int? ProdutoId { get; set; }
    public int? ServicoId { get; set; }
    public decimal Quantidade { get; set; }

    public override void Validate() =>
        AddNotifications(
            CobrancaItemValidation.Validacao(ProdutoId, ServicoId, Quantidade)
        );
}