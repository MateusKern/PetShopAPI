public class NewCobrancaCommand : Command
{
    public bool EstaPaga { get; set; }
    public decimal Desconto { get; set; }
    public int? ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public List<CobrancaItemCommand> Itens { get; set; }

    public override void Validate()
    {
        AddNotifications(
            CobrancaValidation.Validacao(Desconto, ClienteId, ColaboradorId),
            Extensions.ValidateListCommand(Itens, "Itens")
        );
    }
}