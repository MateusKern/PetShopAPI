using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(a => a.Nome).HasMaxLength(ProdutoValidation.NOME_MAXLENGTH).IsRequired();
        builder.Property(a => a.Descricao).HasMaxLength(ProdutoValidation.DESCRICAO_MAXLENGTH);
        builder.Property(a => a.Preco).HasPrecision(ProdutoValidation.PRECO_PRECISION, ProdutoValidation.PRECO_SCALE);
    }
}