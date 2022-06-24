public class NewCobrancaCommand : Command
{
    public bool EstaPaga { get; set; }
    public decimal Desconto { get; set; }
    public int? ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public List<CobrancaItemCommand> Itens { get; set; }

    public override void Validate()
    {
        AddNotifications(CobrancaValidation.Validacao(Desconto, ClienteId, ColaboradorId));

        if (Itens is not null)
            for (int i = 0; i < Itens.Count; i++)
            {
                Itens[i].Validate();
                foreach (var notification in Itens[i].Notifications)
                    AddNotification($"Itens.{i}.{notification.Key}", notification.Message);
            }
    }
}