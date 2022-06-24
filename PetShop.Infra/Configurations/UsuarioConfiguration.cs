using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        var valueComparer = new ValueComparer<IReadOnlyCollection<ETipoAcesso>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToHashSet());

        int numberOfEnums = Enum.GetNames(typeof(ETipoAcesso)).Length;

        builder.Property(a => a.Login).HasMaxLength(UsuarioValidation.LOGIN_MAXLENGTH).IsRequired();
        builder.Property(a => a.Acessos)
            .HasMaxLength(numberOfEnums + (numberOfEnums-1))
            .HasConversion(
                a => string.Join(',', a.Select(b => b.GetHashCode())),
                s => s.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => (ETipoAcesso)Convert.ToInt32(s)).ToList() ?? new List<ETipoAcesso>())
            .Metadata.SetValueComparer(valueComparer);
    }
}