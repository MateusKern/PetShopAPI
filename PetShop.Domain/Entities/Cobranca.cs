public class Cobranca
{
    private readonly List<CobrancaItem> _itens;
    private Cobranca(int id, DateTime dataCobranca, DateTime? dataPagamento, decimal desconto, int? clienteId, int colaboradorId)
    {
        Id = id;
        DataCobranca = dataCobranca;
        DataPagamento = dataPagamento;
        Desconto = desconto;
        ClienteId = clienteId;
        ColaboradorId = colaboradorId;
    }

    public Cobranca(DateTime dataCobranca, DateTime? dataPagamento, decimal desconto, int? clienteId, int colaboradorId, List<CobrancaItem> itens)
    {
        DataCobranca = dataCobranca;
        DataPagamento = dataPagamento;
        Desconto = desconto;
        ClienteId = clienteId;
        ColaboradorId = colaboradorId;
        _itens = itens;
    }

    public int Id { get; set; }
    public DateTime DataCobranca { get; private set; }
    public DateTime? DataPagamento { get; private set; }
    public decimal Desconto { get; private set; }
    public Cliente Cliente { get; private set; }
    public int? ClienteId { get; private set; }
    public Colaborador Colaborador { get; private set; }
    public int ColaboradorId { get; private set; }
    public IReadOnlyCollection<CobrancaItem> Itens { get => _itens; }
}