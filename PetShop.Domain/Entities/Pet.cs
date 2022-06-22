public class Pet
{
    private Pet(int id, string nome, DateOnly? dataNascimento, ETipoPet tipo, string raca, string cor, string porte)
    {
        Id = id;
        Nome = nome;
        DataNascimento = dataNascimento;
        Tipo = tipo;
        Raca = raca;
        Cor = cor;
        Porte = porte;
    }

    public Pet(int id, string nome, DateOnly? dataNascimento, int? idade, ETipoPet tipo, string raca, string cor, string porte)
    {
        Id = id;
        Nome = nome;
        DataNascimento = idade.HasValue ? RetornaDataNascimento(idade.Value) : dataNascimento;
        Tipo = tipo;
        Raca = raca;
        Cor = cor;
        Porte = porte;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public DateOnly? DataNascimento { get; private set; }
    public ETipoPet Tipo { get; private set; }
    public string Raca { get; private set; }
    public string Cor { get; private set; }
    public string Porte { get; private set; }

    private DateOnly RetornaDataNascimento(int idade) =>
        DateOnly.FromDateTime(DateTime.Now.AddYears(-idade));
}