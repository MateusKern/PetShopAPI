namespace PetShop.Domain.Results
{
    public class CobrancaResult
    {
        public int Id { get; set; }
        public DateTime DataCobranca { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Desconto { get; set; }
        public string Cliente { get; set; }
        public int? ClienteId { get; set; }
        public string Colaborador { get; set; }
        public int ColaboradorId { get; set; }
        public IEnumerable<CobrancaItemResult> Itens { get; set; }
    }
}
