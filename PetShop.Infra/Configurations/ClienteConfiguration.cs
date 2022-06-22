using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.Property(a => a.Nome).HasMaxLength(ClienteValidation.NOME_MAXLENGTH).IsRequired();
        builder.Property(a => a.Telefone).HasMaxLength(ClienteValidation.TELEFONE_MAXLENGTH);
        builder.Property(a => a.Email).HasMaxLength(ClienteValidation.EMAIL_MAXLENGTH);
        builder.Property(a => a.Cpf).HasMaxLength(ClienteValidation.CPF_LENGTH);
    }
}