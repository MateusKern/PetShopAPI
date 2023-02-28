namespace PetShop.Domain.Results
{
    public class ClienteResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public List<PetResult> Pets { get; set; }
    }
}