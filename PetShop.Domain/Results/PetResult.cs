namespace PetShop.Domain.Results
{
    public class PetResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Tipo { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public string Porte { get; set; }
    }
}