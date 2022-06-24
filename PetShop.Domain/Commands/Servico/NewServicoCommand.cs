public class NewServicoCommand : Command
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public override void Validate() =>
        AddNotifications(ServicoValidation.Validacao(Nome, Descricao, Preco));
}