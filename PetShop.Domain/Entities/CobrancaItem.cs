public class CobrancaItem
{
    private CobrancaItem(int id, int? produtoId, int? servicoId, decimal quantidade, decimal precoUnitario, int? cobrancaId)
    {
        Id = id;
        ProdutoId = produtoId;
        ServicoId = servicoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        CobrancaId = cobrancaId;
    }

    public CobrancaItem(int? produtoId, int? servicoId, decimal quantidade, decimal precoUnitario)
    {
        ProdutoId = produtoId;
        ServicoId = servicoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public int Id { get; private set; }
    public int? ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public int? ServicoId { get; private set; }
    public Servico Servico { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public int? CobrancaId { get; private set; }
    public Cobranca Cobranca { get; private set; }
}