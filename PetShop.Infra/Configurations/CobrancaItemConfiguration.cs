using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CobrancaItemConfiguration : IEntityTypeConfiguration<CobrancaItem>
{
    public void Configure(EntityTypeBuilder<CobrancaItem> builder)
    {
        builder.Property(a => a.Quantidade).HasPrecision(CobrancaItemValidation.QUANTIDADE_PRECISION, CobrancaItemValidation.QUANTIDADE_SCALE);
        builder.Property(a => a.PrecoUnitario).HasPrecision(CobrancaItemValidation.PRECO_UNITARIO_PRECISION, CobrancaItemValidation.PRECO_UNITARIO_SCALE);
    }
}