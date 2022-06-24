public class Cobranca : EntityBase
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

    public Cobranca(bool estaPaga, decimal desconto, int? clienteId, int colaboradorId)
    {
        DataCobranca = DateTime.Now;
        DataPagamento = estaPaga ? DateTime.Now : null;
        Desconto = desconto;
        ClienteId = clienteId;
        ColaboradorId = colaboradorId;
        _itens = new List<CobrancaItem>();
    }

    public int Id { get; private set; }
    public DateTime DataCobranca { get; private set; }
    public DateTime? DataPagamento { get; private set; }
    public decimal Desconto { get; private set; }
    public Cliente Cliente { get; private set; }
    public int? ClienteId { get; private set; }
    public Colaborador Colaborador { get; private set; }
    public int ColaboradorId { get; private set; }
    public IReadOnlyCollection<CobrancaItem> Itens { get => _itens; }

    public void AddItem(CobrancaItem item)
    {
        if (_itens is not null)
            _itens.Add(item);
    }

    public void PagarCobranca()
    {
        if (DataPagamento.HasValue)
            AddNotification("DataPagamento", "Cobrança já está paga");
        else
            DataPagamento = DateTime.Now;
    }
}