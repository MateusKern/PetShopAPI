public class EditProdutoCommand : Command
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public override void Validate() =>
        AddNotifications(ProdutoValidation.Validacao(Id, Nome, Descricao, Preco));
}