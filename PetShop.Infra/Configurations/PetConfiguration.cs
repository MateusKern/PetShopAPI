using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.Property(a => a.Nome).HasMaxLength(PetValidation.NOME_MAXLENGTH).IsRequired();
        builder.Property(a => a.Raca).HasMaxLength(PetValidation.RACA_MAXLENGTH);
        builder.Property(a => a.Cor).HasMaxLength(PetValidation.COR_MAXLENGTH);
        builder.Property(a => a.Porte).HasMaxLength(PetValidation.PORTE_MAXLENGTH);
    }
}