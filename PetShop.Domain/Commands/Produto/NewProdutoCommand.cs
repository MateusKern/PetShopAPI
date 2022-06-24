public class NewProdutoCommand : Command
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public override void Validate() =>
        AddNotifications(ProdutoValidation.Validacao(Nome, Descricao, Preco));
}