public class PetCommand : Command
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public int? Idade { get; set; }
    public ETipoPet Tipo { get; set; }
    public string Raca { get; set; }
    public string Cor { get; set; }
    public string Porte { get; set; }

    public override void Validate()
    {
        AddNotifications(PetValidation.Validacao(Nome, Raca, Cor, Porte));
    }
}