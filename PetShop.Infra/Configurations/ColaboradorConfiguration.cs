using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
{
    public void Configure(EntityTypeBuilder<Colaborador> builder)
    {
        builder.Property(a => a.Nome).HasMaxLength(ColaboradorValidation.NOME_MAXLENGTH).IsRequired();
        builder.Property(a => a.Email).HasMaxLength(ClienteValidation.EMAIL_MAXLENGTH);
    }
}