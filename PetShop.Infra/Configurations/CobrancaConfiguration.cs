using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CobrancaConfiguration : IEntityTypeConfiguration<Cobranca>
{
    public void Configure(EntityTypeBuilder<Cobranca> builder)
    {
        builder.Property(a => a.DataCobranca).IsRequired();
        builder.Property(a => a.Desconto).HasPrecision(CobrancaValidation.DESCONTO_PRECISION, CobrancaValidation.DESCONTO_SCALE);
    }
}