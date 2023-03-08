namespace PetShop.Domain.Results
{
    public class CobrancaItemResult
    {
        public int Id { get; private set; }
        public int? ProdutoId { get; private set; }
        public string Produto { get; private set; }
        public int? ServicoId { get; private set; }
        public string Servico { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}
