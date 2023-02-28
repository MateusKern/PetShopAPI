public class EditClienteCommand : Command
{
    private string _telefone { get; set; }
    private string _cpf { get; set; }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get => _telefone; set => _telefone = value.RemoveSpecialCharacters(); }
    public string Email { get; set; }
    public string Cpf { get => _cpf; set => _cpf = value.RemoveSpecialCharacters(); }
    public List<PetCommand> Pets { get; set; }

    public override void Validate()
    {
        AddNotifications(
            ClienteValidation.Validacao(Nome, Telefone, Email, Cpf),
            Extensions.ValidateListCommand(Pets, "Pets")
        );
    }
}