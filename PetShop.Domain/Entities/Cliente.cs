public class Cliente : EntityBase
{
    private List<Pet> _pets;

    private Cliente(int id, string nome, string telefone, string email, string cpf)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Cpf = cpf;
    }

    public Cliente(string nome, string telefone, string email, string cpf, IEnumerable<Pet> pets)
    {
        EditarCliente(nome, telefone, email, cpf, pets);
        Usuario = new Usuario(email, new List<ETipoAcesso>() { ETipoAcesso.Cliente });
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public Usuario Usuario { get; private set; }
    public IReadOnlyCollection<Pet> Pets { get => _pets; }

    public void EditarCliente(string nome, string telefone, string email, string cpf, IEnumerable<Pet> pets)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Cpf = cpf;
        _pets = pets.ToList();
    }
}