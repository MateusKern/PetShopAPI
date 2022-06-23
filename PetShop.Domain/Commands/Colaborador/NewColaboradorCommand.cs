public class NewColaboradorCommand : Command
{
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string Email { get; set; }
    public List<ETipoAcesso> Acessos { get; set; }

    public override void Validate()
    {
        AddNotifications(ColaboradorValidation.Validacao(Nome, DataNascimento, Email, Acessos));
    }
}