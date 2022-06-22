using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.Property(a => a.Nome).HasMaxLength(ServicoValidation.NOME_MAXLENGTH).IsRequired();
        builder.Property(a => a.Descricao).HasMaxLength(ServicoValidation.DESCRICAO_MAXLENGTH);
        builder.Property(a => a.Preco).HasPrecision(ServicoValidation.PRECO_PRECISION, ServicoValidation.PRECO_SCALE);
    }
}